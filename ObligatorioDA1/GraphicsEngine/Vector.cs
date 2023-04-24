using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    public class Vector
    {
        private double _x;
        public double X
        {
            get => _x;
            set
            {
                if (value > 1)
                {
                    throw new ArgumentOutOfRangeException("X coordinate can not be greater than 1");
                }
                _x = value;
            }
        }

        public double Y { get; set; }
        public double Z { get; set; }
    }
}
