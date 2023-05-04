using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    public class Color : Vector
    {
        private decimal _x { get; set; }
        private decimal _y { get; set; }
        private decimal _z { get; set; }
        public decimal X
        {
            get => _x;
            set
            {
                _x = value;
            }
        }

        public decimal Y
        {
            get => _y;
            set
            {
                _y = value;
            }
        }

        public decimal Z
        {
            get => _z;
            set
            {
                _z = value;
            }
        }

        public int Red()
        {
            return CalculateCoordinateColor(X);
        }

        public int Green()
        {
            return CalculateCoordinateColor(Y);
        }

        public int Blue()
        {
            return CalculateCoordinateColor(Z);
        }

        private int CalculateCoordinateColor(decimal coordinate)
        {
            decimal roundedCoordinateColorValue = RoundedCoordinateColor(coordinate);
            return ConvertedColorToInt32(roundedCoordinateColorValue);
        }

        private decimal RoundedCoordinateColor(decimal coordinate)
        {
            return Math.Round(CoordinateColorConversion(coordinate), MidpointRounding.AwayFromZero);
        }

        private decimal CoordinateColorConversion(decimal coordinate)
        {
            return coordinate * 255;
        }

        private int ConvertedColorToInt32(decimal coordinate)
        {
            return Convert.ToInt32(coordinate);
        }
    }
}
