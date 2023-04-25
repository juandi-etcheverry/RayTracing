using System;

namespace GraphicsEngine
{
    public class Vector
    {
        private double _x;
        private double _y;
        private double _z;
        public double X
        {
            get => _x;
            set
            {
                ValidateVectorIsBetweenZeroAndOne(value, "X");
                _x = value;
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                ValidateVectorIsBetweenZeroAndOne(value, "Y");
                _y = value;
            }
        }
        public double Z
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
            return Convert.ToInt32(Math.Round(_x * 255));
        }

        public int Green()
        {
            return Convert.ToInt32(Math.Round(_y * 255));
        }



        private void ValidateVectorIsBetweenZeroAndOne(double value, string coordinateName)
        {
            ValidateVectorIsZeroOrGreater(value, coordinateName);
            ValidateVectorIsOneOrBelow(value, coordinateName);
        }

        private void ValidateVectorIsZeroOrGreater(double value, string coordinateName)
        {
            if (value < 0) ThrowVectorCoordinateIsOutOfRange(coordinateName);

        }

        private void ValidateVectorIsOneOrBelow(double value, string coordinateName)
        {
            if (value > 1) ThrowVectorCoordinateIsOutOfRange(coordinateName);
        }

        private void ThrowVectorCoordinateIsOutOfRange(string coordinateName)
        {
            throw new ArgumentOutOfRangeException("{0} coordinate must be between 0 and 1", coordinateName);
        }
    }
}
