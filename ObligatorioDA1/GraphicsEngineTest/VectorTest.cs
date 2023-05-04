using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphicsEngine;

namespace GraphicsEngineTest
{
    [TestClass]
    public class VectorTest
    {
        private Vector vForColors;
        private Vector nullVector;

        [TestInitialize]
        public void CreateVectorForColors()
        {
            vForColors = new Vector()
            {
                X = 0.3m,
                Y = 0.6m,
                Z = 0.9m
            };
            nullVector = new Vector()
            {
                X = 0,
                Y = 0,
                Z = 0
            };
        }

        [TestMethod]
        public void CreateVector_ValidXYZ_OK()
        {
            Vector v = new Vector()
            {
                X = 0.3m,
                Y = 1.0m,
                Z = 0.0m
            };

            Assert.AreEqual((0.3m, 1.0m, 0.0m), (v.X, v.Y, v.Z));
        }

        [TestMethod]
        public void GetColors_GetRed_OK()
        {
            int redAmount = vForColors.Red();
            Assert.AreEqual(77, redAmount);
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
            Assert.AreEqual(230, blueAmount);
        }

        [TestMethod]
        public void AddVector_NullVector_OK()
        {
            Vector sum = vForColors.Add(nullVector);
            Assert.AreEqual((vForColors.X, vForColors.Y, vForColors.Z), (sum.X, sum.Y, sum.Z));
        }

        [TestMethod]
        public void AddVector_ValidVector_OK()
        {
            Vector sum = vForColors.Add(vForColors);
            Assert.AreEqual((2 * vForColors.X, 2 * vForColors.Y, 2 * vForColors.Z), (sum.X, sum.Y, sum.Z));
        }

        [TestMethod]
        public void SubstractVector_ValidVector_OK()
        {
            Vector sub = vForColors.Substract(vForColors);
            Assert.AreEqual((0m, 0m, 0m), (sub.X, sub.Y, sub.Z));
        }

        [TestMethod]
        public void MultiplyVector_Zero_OK()
        {
            Vector mult = vForColors.Multiply(0);
            Assert.AreEqual((0m, 0m, 0m), (mult.X, mult.Y, mult.Z));
        }

        [TestMethod]
        public void MultiplyVector_Three_OK()
        {
            Vector mult = vForColors.Multiply(3);
            Assert.AreEqual((0.9m, 1.8m, 2.7m), (mult.X, mult.Y, mult.Z));
        }

        [TestMethod]
        public void DivideVector_Three_OK()
        {
            Vector div = vForColors.Divide(3);
            Assert.AreEqual((0.1m, 0.2m, 0.3m), (div.X, div.Y, div.Z));
        }

        [ExpectedException(typeof(System.DivideByZeroException))]
        [TestMethod]
        public void DivideVector_Zero_FAIL()
        {
            Vector div = vForColors.Divide(0);
        }

        [TestMethod]
        public void VectorLength_NullVector_OK()
        {
            decimal length = nullVector.Length();
            Assert.AreEqual(0, length);
        }

        [TestMethod]
        public void VectorLength_ValidVector_OK()
        {
            Vector validVector = new Vector()
            {
                X = 1,
                Y = 2,
                Z = 2
            };
            decimal length = validVector.Length();
            Assert.AreEqual(3, length);
        }
    }
}