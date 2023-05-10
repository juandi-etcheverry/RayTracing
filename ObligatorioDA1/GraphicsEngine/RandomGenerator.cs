using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal static class RandomGenerator
    {
        public static bool ShowDefaultValue { get; set; }
        public static double DefaultValue { get; set; }
        private static Random random = new Random();

        public static double NextDouble()
        {
            if (ShowDefaultValue) return DefaultValue;
            return random.NextDouble();
        }
    }
}
