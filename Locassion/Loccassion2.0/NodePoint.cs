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
    class NodePoint : AbstractNode
    {
        private int index;

        public NodePoint(AbstractShape owner, int index) : base (owner)
        {
            this.index = index;
        }

        protected override PointF getCenterPoint()
        {
            return owner.points[index];
        }

        protected override void moveHelper(PointF[] deltaHelper)
        {
            owner.points[index] = new PointF(owner.points[index].X + deltaHelper[0].X, owner.points[index].Y + deltaHelper[0].Y);
        }
    }
}
