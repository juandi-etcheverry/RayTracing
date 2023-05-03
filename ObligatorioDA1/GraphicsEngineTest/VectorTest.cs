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

        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //[TestMethod]
        //public void CreateVector_InvalidX_Fail()
        //{
        //    Vector v = new Vector()
        //    {
        //        X = 1.2m,
        //        Y = 1.0m,
        //        Z = 0.0m
        //    };
        //}

        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //[TestMethod]
        //public void CreateVector_InvalidY_Fail()
        //{
        //    Vector v = new Vector()
        //    {
        //        X = 0.1m,
        //        Y = -0.4m,
        //        Z = 0.0m
        //    };
        //}

        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //[TestMethod]
        //public void CreateVector_InvalidZ_Fail()
        //{
        //    Vector v = new Vector()
        //    {
        //        X = 0.1m,
        //        Y = 0.4m,
        //        Z = 1.4m
        //    };
        //}

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
    }
}
