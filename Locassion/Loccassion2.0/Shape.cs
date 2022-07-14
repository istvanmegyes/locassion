using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Loccassion2._0
{
    [Serializable]
    class Shape : AbstractShape
    {
        public string name;
 
        private Shape(PointF center,string name="") : base (center)
        {
            this.name = name;
        }

        public static Shape createSquare(PointF center, float width)
        {
            Shape temp = new Shape(center);

            float w = width / 2;
            PointF bottomLeft = new PointF(- w, + w);
            PointF bottomRight = new PointF( + w, + w);
            PointF topRight = new PointF( + w,  - w);
            PointF topLeft = new PointF(- w,  - w);

            temp.points.Add(bottomLeft);
            temp.points.Add(bottomRight);
            temp.points.Add(topRight);
            temp.points.Add(topLeft);

            temp.calculateBoundingBox(temp.points.ToArray());
            temp.fillNodePoints();

            return temp;
        }

        public static Shape createUShape(PointF center, float width)
        {
            Shape temp = new Shape(center);

            float w = width / 2;
            float w2 = width / 9;

            PointF bottomLeft = new PointF(-w, +w);
            PointF bottomRight = new PointF(+w, +w);
            PointF topRight = new PointF(+w, -w);
            PointF topLeft = new PointF(-w, -w);
            PointF topLeft2 = new PointF(-w2, -w);
            PointF topRight2 = new PointF(+w2, -w);
            PointF midLeft = new PointF(-w2, +w2);
            PointF midRight = new PointF(+w2, +w2);

            temp.points.Add(bottomLeft);
            temp.points.Add(topLeft);
            temp.points.Add(topLeft2);
            temp.points.Add(midLeft);
            temp.points.Add(midRight);
            temp.points.Add(topRight2);
            temp.points.Add(topRight);
            temp.points.Add(bottomRight);

            temp.calculateBoundingBox(temp.points.ToArray());
            temp.fillNodePoints();

            return temp;
        }

        public static Shape createTShape(PointF center, float width)
        {
            Shape temp = new Shape(center);

            float w = width / 2;
            float w2 = width /5;

            PointF topLeft = new PointF(-w, -w);
            PointF topRight = new PointF(+w, -w);
            PointF midRight = new PointF(+w, -w2);
            PointF midRight2 = new PointF(+w2, -w2);
            PointF bottomRight = new PointF(+w2, +w);
            PointF bottomLeft = new PointF(-w2, +w);
            PointF midLeft2 = new PointF(-w2, -w2);
            PointF midLeft = new PointF(-w, -w2);

            temp.points.Add(topLeft);
            temp.points.Add(topRight);
            temp.points.Add(midRight);
            temp.points.Add(midRight2);
            temp.points.Add(bottomRight);
            temp.points.Add(bottomLeft);
            temp.points.Add(midLeft2);
            temp.points.Add(midLeft);     

            temp.calculateBoundingBox(temp.points.ToArray());
            temp.fillNodePoints();

            return temp;
        }

        public static Shape createLShape(PointF center, float width)
        {
            Shape temp = new Shape(center);

            float w = width / 2;
            float w2 = w / 5;
            PointF bottomLeft = new PointF(-w, +w);
            PointF bottomRight = new PointF(+w, +w);
            PointF topRight = new PointF(+w, +w2);
            PointF topLeft = new PointF(-w, -w);
            PointF topLeft2 = new PointF(-w2, -w);
            PointF mid = new PointF(-w2, +w2);

            temp.points.Add(bottomLeft);
            temp.points.Add(topLeft);
            temp.points.Add(topLeft2);
            temp.points.Add(mid);
            temp.points.Add(topRight);
            temp.points.Add(bottomRight);

            temp.calculateBoundingBox(temp.points.ToArray());
            temp.fillNodePoints();

            return temp;
        }

        protected override void drawHelper(PointF[] worldPoints, Graphics g, Camera camera)
        {
            if (resize)
            {
                boundingBox.draw(g);

                foreach (var item in nodePoints)
                {
                    item.draw(g, transform, camera);
                }
            }
        }
      
        protected override void fillNodePointsHelper()
        {
            for (int i = 0; i < points.Count; i++)
            {
                nodePoints.Add(new NodePoint(this, i));
            }
        }
    }
}
