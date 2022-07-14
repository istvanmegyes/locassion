using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Loccassion2._0
{
    [Serializable]
    class Floor
    {
        public List<AbstractShape> shapes = new List<AbstractShape>();
        public Camera camera = new Camera();

        public Floor(){}

        public void addAbstractShape(AbstractShape shape)
        {
            shapes.Add(shape);
        }

    }
}
