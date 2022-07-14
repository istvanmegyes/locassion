using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Loccassion2._0
{
    [Serializable]
    class BoundingBox
    {
        public PointF BottomLeft { get; set; }
        public PointF UpRight { get; set; }

        public BoundingBox(PointF bottomLeft, PointF upRight)
        {
            BottomLeft = bottomLeft;
            UpRight = upRight;
        }

        public BoundingBox() { }

        public void Set(PointF bottomLeft, PointF upRight)
        {
            BottomLeft = bottomLeft;
            UpRight = upRight;
        }

        public void draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black))
            {
                pen.Width = 2.4f;
                pen.DashPattern = new float[] { 4.0F, 4.0F, 3.0F, 3.0F };
                g.DrawRectangle(pen,BottomLeft.X,UpRight.Y, UpRight.X - BottomLeft.X, BottomLeft.Y - UpRight.Y);
            }
        }
    }
}
