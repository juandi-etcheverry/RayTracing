using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace GraphicsEngine
{
    internal abstract class ScatterStrategy
    {
        internal HitRecord hitRecord { get; set; }
        internal Ray incomingRay { get; set; }

        internal abstract Ray Scatter();
        internal abstract bool CanExecute();
    }
}
