using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class HitRecord
    {
        internal decimal ScalingFactor { get; set; }
        internal Vector IntersectionPoint { get; set; }
        internal Vector Normal { get; set; }
        internal Color Attenuation { get; set; }
    }
}
