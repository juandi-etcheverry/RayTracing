using System;

namespace GraphicsEngine
{
    internal static class RandomGenerator
    {
        private static readonly Random random = new Random();
        public static bool ShowDefaultValue { get; set; }
        public static double DefaultValue { get; set; }

        public static double NextDouble()
        {
            if (ShowDefaultValue) return DefaultValue;
            return random.NextDouble();
        }
    }
}