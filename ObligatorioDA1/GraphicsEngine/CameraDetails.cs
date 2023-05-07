using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class CameraDetails
    {
        internal Vector LookFrom { get; set; }
        internal Vector LookAt { get; set; }
        internal Vector Up { get; set; }
        internal double FieldOfView { get; set; }
        internal decimal AspectRatio { get; set; }
    }
}
