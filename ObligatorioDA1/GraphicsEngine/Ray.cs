using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    public class Ray
    {
        public Vector origin { get; set; }
        public Vector direction { get; set; }

        public Vector PointAt(decimal directionScalar)
        {
            return origin.Add(direction.Multiply(directionScalar));
        }
    }
}
