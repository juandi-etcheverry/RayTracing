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
    public class ColorTest
    {
        private Color colorVector;

        [TestInitialize]
        public void CreateVectorForColors()
        {
            colorVector = new Color()
            {
                X = 0.3m,
                Y = 0.6m,
                Z = 0.9m
            };
        }


        [TestMethod]
        public void GetColors_GetRed_OK()
        {
            int redAmount = colorVector.Red();
            Assert.AreEqual(77, redAmount);
        }

        [TestMethod]
        public void GetColors_GetGreen_OK()
        {
            int greenAmount = colorVector.Green();
            Assert.AreEqual(153, greenAmount);
        }

        [TestMethod]
        public void GetColors_GetBlue_OK()
        {
            int blueAmount = colorVector.Blue();
            Assert.AreEqual(230, blueAmount);
        }
    }
}
