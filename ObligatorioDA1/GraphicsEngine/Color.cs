using System;

namespace GraphicsEngine
{
    public class Color
    {
        private decimal _r { get; set; }
        private decimal _g { get; set; }
        private decimal _b { get; set; }

        public decimal R
        {
            get => _r;
            set
            {
                ValidateColorIsBetweenZeroAndOne(value, "R");
                _r = value;
            }
        }

        public decimal G
        {
            get => _g;
            set
            {
                ValidateColorIsBetweenZeroAndOne(value, "G");
                _g = value;
            }
        }

        public decimal B
        {
            get => _b;
            set
            {
                ValidateColorIsBetweenZeroAndOne(value, "B");
                _b = value;
            }
        }

        public int Red()
        {
            return CalculateCoordinateColor(R);
        }

        public int Green()
        {
            return CalculateCoordinateColor(G);
        }

        public int Blue()
        {
            return CalculateCoordinateColor(B);
        }

        private int CalculateCoordinateColor(decimal coordinate)
        {
            var roundedCoordinateColorValue = RoundedCoordinateColor(coordinate);
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

        private void ValidateColorIsBetweenZeroAndOne(decimal value, string coordinateName)
        {
            ValidateColorIsZeroOrGreater(value, coordinateName);
            ValidateColorIsOneOrBelow(value, coordinateName);
        }

        private void ValidateColorIsZeroOrGreater(decimal value, string coordinateName)
        {
            if (value < 0) ThrowColorCoordinateIsOutOfRange(coordinateName);
        }

        private void ValidateColorIsOneOrBelow(decimal value, string coordinateName)
        {
            if (value > 1) ThrowColorCoordinateIsOutOfRange(coordinateName);
        }

        private void ThrowColorCoordinateIsOutOfRange(string coordinateName)
        {
            throw new ArgumentOutOfRangeException("{0} color value must be between 0 and 1", coordinateName);
        }
    }
}