using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphicsEngine;

namespace GraphicsEngineTest
{
    [TestClass]
    public class VectorTest
    {
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


    }
}
