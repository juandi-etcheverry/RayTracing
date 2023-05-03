using System;

namespace GraphicsEngine
{
    public class Vector
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public int Red()
        {
            return Convert.ToInt32(Math.Round(X * 255, MidpointRounding.AwayFromZero));
        }

        public int Green()
        {
            return Convert.ToInt32(Math.Round(Y * 255, MidpointRounding.AwayFromZero));
        }

        public int Blue()
        {
            return Convert.ToInt32(Math.Round(Z * 255, MidpointRounding.AwayFromZero));
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

        public Vector Add(Vector vector)
        {
            return new Vector()
            {
                X = this.X + vector.X,
                Y = this.Y + vector.Y,
                Z = this.Z + vector.Z
            };
        }

        public Vector Substract(Vector vector)
        {
            return new Vector()
            {
                X = this.X - vector.X,
                Y = this.Y - vector.Y,
                Z = this.Z - vector.Z
            };
        }

        public Vector Multiply(decimal scalar)
        {
            return new Vector()
            {
                X = this.X * scalar,
                Y = this.Y * scalar,
                Z = this.Z * scalar
            };
        }

        public Vector Divide(decimal scalar)
        {
            return new Vector()
            {
                X = this.X / scalar,
                Y = this.Y / scalar,
                Z = this.Z / scalar
            };
        }

        public decimal Length()
        {
            return 0;
        }
    }
}
