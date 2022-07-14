using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Loccassion2._0
{
    [Serializable]
    abstract class AbstractNode
    {
        protected AbstractShape owner;
        PointF[] worldPoint;

        protected abstract void moveHelper(PointF[] deltaHelper);
        protected abstract PointF getCenterPoint();

        public AbstractNode(AbstractShape owner)
        {
            this.owner = owner;
        }

        public bool isInsideAbstractNode(PointF p)
        {
            PointF w = worldPoint[0];
            bool b = p.X > w.X - 5 && p.X < w.X + 5 && p.Y > w.Y - 5 && p.Y < w.Y + 5;

            return b;
        }

        public void move(PointF delta)
        {
            PointF[] deltaHelper = new PointF[] { delta };

            Matrix rotate = new Matrix();
            rotate.Rotate(-owner.orientation);
            rotate.TransformPoints(deltaHelper);
            moveHelper(deltaHelper);
        }

        public void draw(Graphics g, Matrix transform, Camera camera)
        {
            worldPoint = new PointF[] { getCenterPoint() };
            transform.TransformPoints(worldPoint);

            using (Brush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, worldPoint[0].X - 2.5f*camera.zoomLevel, worldPoint[0].Y - 2.5f*camera.zoomLevel, 5 * camera.zoomLevel, 5 * camera.zoomLevel);
            }
        }
    }
}
