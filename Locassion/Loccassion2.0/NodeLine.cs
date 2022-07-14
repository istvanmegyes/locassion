using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loccassion2._0
{
    [Serializable]
    class NodeLine : AbstractNode
    {
        int index1, index2;

        public NodeLine(AbstractShape owner, int index1, int index2) : base(owner)
        {
            this.index1 = index1;
            this.index2 = index2;
        }

        protected override PointF getCenterPoint()
        {
            PointF p1 = owner.points[index1];
            PointF p2 = owner.points[index2];

            float maxX = Math.Max(p1.X, p2.X);
            float minX = Math.Min(p1.X, p2.X);
            float maxY = Math.Max(p1.Y, p2.Y);
            float minY = Math.Min(p1.Y, p2.Y);

            return new PointF((maxX + minX) / 2, (maxY + minY) / 2);
        }

        protected override void moveHelper(PointF[] deltaHelper)
        {
            // Az egér kurzor koordinátái
            float X = deltaHelper[0].X;
            float Y = deltaHelper[0].Y;
            
            // Az adott oldalt összekötő két pont
            PointF p1 = owner.points[index1];
            PointF p2 = owner.points[index2];

            PointF vX = new PointF(p2.X - p1.X, p2.Y - p1.Y);
            PointF vY = new PointF(vX.Y, - vX.X); // merőleges a vX-re
            float length = (float)Math.Sqrt(X * X + Y * Y);

            float vYLength = (float)Math.Sqrt(vY.X * vY.X + vY.Y * vY.Y);
            
            float cosA = (vY.X * X + vY.Y * Y) / (vYLength*length);

            float moveLength = length * cosA;

            vY.X = vY.X / vYLength;
            vY.Y = vY.Y / vYLength;

            vY.X = vY.X * moveLength;
            vY.Y = vY.Y * moveLength;

            owner.points[index1] = new PointF(p1.X + vY.X, p1.Y + vY.Y);
            owner.points[index2] = new PointF(p2.X + vY.X, p2.Y + vY.Y);
        }
    }
}
