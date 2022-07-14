using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Loccassion2._0
{   [Serializable]
    abstract class AbstractShape
    {
        public List<PointF> points = new List<PointF>();   // a pontok a modell koordinátarendszerben
        public PointF position = new PointF();              // eltolás koordinátája (a vektorunk)
        public float orientation = 0.0f;
        Color color;
        [NonSerialized]
        public Matrix transform = new Matrix();
        public bool resize = false;
        protected List<AbstractNode> nodePoints = new List<AbstractNode>();
        public BoundingBox boundingBox = new BoundingBox(); // a shapet körülvevő négyszög
        
        protected abstract void drawHelper(PointF[] worldPoints, Graphics g, Camera camera);
        protected abstract void fillNodePointsHelper();

        public Color Color {set => color = value; }

        public AbstractShape(PointF center)
        {
            position = center;
            color = Color.FromArgb(255,185,97);
        }

        public void draw(Graphics g, float width, float height, Floor floor)
        {
            PointF[] worldPoints = new PointF[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                worldPoints[i].X = points[i].X;
                worldPoints[i].Y = points[i].Y;
            }

            if (transform==null) transform = new Matrix();
            transform.Reset();

            // nagyon fontos a sorrend, valószínűleg csak ebben a variációban működik 
            transform.Rotate(orientation, MatrixOrder.Append);
            transform.Translate(position.X, position.Y, MatrixOrder.Append);
            transform.Translate(-floor.camera.position.X, -floor.camera.position.Y, MatrixOrder.Append);
            transform.Scale(floor.camera.zoomLevel, floor.camera.zoomLevel, MatrixOrder.Append);
            transform.TransformPoints(worldPoints);

            calculateBoundingBox(worldPoints);

            using (Pen pen = new Pen(Color.Black))
            {
                //pen.Width = 1.5f;
                g.DrawPolygon(pen, worldPoints);
                g.FillPolygon(new SolidBrush(color), worldPoints);
            }

            drawHelper(worldPoints, g, floor.camera);
        }

        public void move(PointF delta)
        {
            position.X += delta.X;
            position.Y += delta.Y;
        }

        public bool isInsideAbstractShape(PointF p)
        {
            var b = boundingBox;

            return p.X < b.UpRight.X && p.X > b.BottomLeft.X && p.Y < b.BottomLeft.Y && p.Y > b.UpRight.Y;
        }
        public void toggleShapeResize()
        {
            resize = !resize;
        }

        public AbstractNode findActiveNode(PointF p)
        {
            return nodePoints.Find(match => match.isInsideAbstractNode(p));
        }

        protected void fillNodePoints()
        {
            fillNodePointsHelper();
 
            for (int i = 1; i < points.Count; i++)
            {
                nodePoints.Add(new NodeLine(this, i - 1, i));
            }
            nodePoints.Add(new NodeLine(this, points.Count - 1, 0));
        }

        protected void calculateBoundingBox(PointF[] shapePoints)
        {
            float minX = shapePoints.Min(point => point.X);
            float maxX = shapePoints.Max(point => point.X);
            float minY = shapePoints.Min(point => point.Y);
            float maxY = shapePoints.Max(point => point.Y);

            boundingBox.Set(new PointF(minX, maxY), new PointF(maxX, minY)); // beállítja az alakzat bounding boxának értékeit
        }
    }
}
