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
                ValidateVectorIsBetweenZeroAndOne(value, "X");
                _x = value;
            }
        }

        public decimal Y
        {
            get => _y;
            set
            {
                ValidateVectorIsBetweenZeroAndOne(value, "Y");
                _y = value;
            }
        }

        public decimal Z
        {
            get => _z;
            set
            {
                ValidateVectorIsBetweenZeroAndOne(value, "Z");
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

        private void ValidateVectorIsBetweenZeroAndOne(decimal value, string coordinateName)
        {
            ValidateVectorIsZeroOrGreater(value, coordinateName);
            ValidateVectorIsOneOrBelow(value, coordinateName);
        }

        private void ValidateVectorIsZeroOrGreater(decimal value, string coordinateName)
        {
            if (value < 0) ThrowVectorCoordinateIsOutOfRange(coordinateName);

        }

        private void ValidateVectorIsOneOrBelow(decimal value, string coordinateName)
        {
            if (value > 1) ThrowVectorCoordinateIsOutOfRange(coordinateName);
        }

        private void ThrowVectorCoordinateIsOutOfRange(string coordinateName)
        {
            throw new ArgumentOutOfRangeException("{0} coordinate must be between 0 and 1", coordinateName);
        }
    }
}
