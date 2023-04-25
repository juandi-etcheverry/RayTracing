using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphicsEngine;

namespace GraphicsEngineTest
{
    [TestClass]
    public class VectorTest
    {
        private Vector vForColors;

        [TestInitialize]
        public void CreateVectorForColors()
        {
            vForColors = new Vector()
            {
                X = 0.3,
                Y = 0.6,
                Z = 0.9
            };
        }

        [TestMethod]
        public void CreateVector_ValidXYZ_OK()
        {
            Vector v = new Vector()
            {
                X = 0.3,
                Y = 1.0,
                Z = 0.0
            };

            Assert.AreEqual((0.3, 1.0, 0.0), (v.X, v.Y, v.Z));
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CreateVector_InvalidX_Fail()
        {
            Vector v = new Vector()
            {
                X = 1.2,
                Y = 1.0,
                Z = 0.0
            };
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CreateVector_InvalidY_Fail()
        {
            Vector v = new Vector()
            {
                X = 0.1,
                Y = -0.4,
                Z = 0.0
            };
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CreateVector_InvalidZ_Fail()
        {
            Vector v = new Vector()
            {
                X = 0.1,
                Y = 0.4,
                Z = 1.4
            };
        }

        [TestMethod]
        public void GetColors_GetRed_OK()
        {
            int redAmount = vForColors.Red();
            Assert.AreEqual(76, redAmount);
        }

        [TestMethod]
        public void GetColors_GetGreen_OK()
        {
            int greenAmount = vForColors.Green();
            Assert.AreEqual(153, greenAmount);
        }

        [TestMethod]
        public void GetColors_GetBlue_OK()
        {
            int blueAmount = vForColors.Blue();
            Assert.AreEqual(229, blueAmount);
        }

    }
}
