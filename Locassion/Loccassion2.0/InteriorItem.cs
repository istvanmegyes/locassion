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
    class InteriorItem : AbstractShape
    {
        private InteriorItem(PointF center) :base(center) { this.Color = Color.DimGray; }

        public static InteriorItem createInteriorItem(PointF center, float width, float height)
        {
            InteriorItem temp = new InteriorItem(center);

            float w = width / 2;
            float h = height / 2;
            PointF bottomLeft = new PointF(-w, +h);
            PointF bottomRight = new PointF(+w, +h);
            PointF topRight = new PointF(+w, -w);
            PointF topLeft = new PointF(-w, -w);

            temp.points.Add(bottomLeft);
            temp.points.Add(bottomRight);
            temp.points.Add(topRight);
            temp.points.Add(topLeft);

            temp.calculateBoundingBox(temp.points.ToArray());
            
            return temp;
        }

        protected override void drawHelper(PointF[] worldPoints, Graphics g, Camera camera) { }

        protected override void fillNodePointsHelper() { }

    }
}
