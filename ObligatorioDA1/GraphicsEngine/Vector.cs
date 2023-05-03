using System;

namespace GraphicsEngine
{
    public class Vector
    {
        private decimal _x;
        private decimal _y;
        private decimal _z;
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

        // C# Math.Round method rounds down in .5 values
        public int Red()
        {
            return Convert.ToInt32(Math.Round(_x * 255, MidpointRounding.AwayFromZero));
        }

        public int Green()
        {
            return Convert.ToInt32(Math.Round(_y * 255, MidpointRounding.AwayFromZero));
        }

        public int Blue()
        {
            return Convert.ToInt32(Math.Round(_z * 255, MidpointRounding.AwayFromZero));
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

        public Vector Add(Vector vector)
        {
            return new Vector()
            {
                X = this.X,
                Y = this.Y,
                Z = this.Z
            };
        }
    }
}
