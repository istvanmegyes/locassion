using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Loccassion2._0
{
    [Serializable]
    class Camera
    {
        public PointF position;
        public float zoomLevel = 1;

        public Camera(float x = 0, float y =0)
        {
            position = new PointF(x, y);
        }
    }
}
