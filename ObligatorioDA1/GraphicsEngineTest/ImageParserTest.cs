using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphicsEngineTest
{

    [TestClass]
    public class ImageParserTest
    {
        private Color red;
        private Color green;
        private Color blue;
        private Color black;

        [TestInitialize]
        public void SetupColors()
        {
            red = new Color() { R = 1, G = 0, B = 0 };
            green = new Color() { R = 0, G = 1, B = 0 };
            blue = new Color() { R = 0, G = 0, B = 1 };
            black = new Color() { R = 0, G = 0, B = 0 };
        }
        [TestMethod]
        public void ParseTest_2by2Image_OK()
        {
            Color[,] data = { { red, green }, { blue, black } };
            var parser = new ImageParser(data)
            {
                HorizontalResolution = 2,
                VerticalResolution = 2,
            };
            string result = parser.Parse();
            Assert.AreEqual("P3\n2 2\n255\n255 0 0\n0 255 0\n0 0 255\n0 0 0\n", result);
        }

    }
}
