using System;
using GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphicsEngineTest
{
    [TestClass]
    public class VectorTest
    {
        private Vector basicVector;
        private Vector nullVector;

        [TestInitialize]
        public void CreateVectorsForTesting()
        {
            basicVector = new Vector
            {
                X = 0.3m,
                Y = 0.6m,
                Z = 0.9m
            };
            nullVector = new Vector
            {
                X = 0,
                Y = 0,
                Z = 0
            };
        }

        [TestMethod]
        public void CreateVector_ValidXYZ_OK()
        {
            var v = new Vector
            {
                X = 0.3m,
                Y = 1.0m,
                Z = 0.0m
            };

            Assert.AreEqual((0.3m, 1.0m, 0.0m), (v.X, v.Y, v.Z));
        }

        [TestMethod]
        public void AddVector_NullVector_OK()
        {
            var sum = basicVector.Add(nullVector);
            Assert.AreEqual((basicVector.X, basicVector.Y, basicVector.Z), (sum.X, sum.Y, sum.Z));
        }

        [TestMethod]
        public void AddVector_ValidVector_OK()
        {
            var sum = basicVector.Add(basicVector);
            Assert.AreEqual((2 * basicVector.X, 2 * basicVector.Y, 2 * basicVector.Z), (sum.X, sum.Y, sum.Z));
        }

        [TestMethod]
        public void SubtractVector_ValidVector_OK()
        {
            var sub = basicVector.Subtract(basicVector);
            Assert.AreEqual((0m, 0m, 0m), (sub.X, sub.Y, sub.Z));
        }

        [TestMethod]
        public void MultiplyVector_Zero_OK()
        {
            var mult = basicVector.Multiply(0);
            Assert.AreEqual((0m, 0m, 0m), (mult.X, mult.Y, mult.Z));
        }

        [TestMethod]
        public void MultiplyVector_Three_OK()
        {
            var mult = basicVector.Multiply(3);
            Assert.AreEqual((0.9m, 1.8m, 2.7m), (mult.X, mult.Y, mult.Z));
        }

        [TestMethod]
        public void DivideVector_Three_OK()
        {
            var div = basicVector.Divide(3);
            Assert.AreEqual((0.1m, 0.2m, 0.3m), (div.X, div.Y, div.Z));
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void DivideVector_Zero_FAIL()
        {
            var div = basicVector.Divide(0);
        }

        [TestMethod]
        public void VectorLength_NullVector_OK()
        {
            var length = nullVector.Length();
            Assert.AreEqual(0, length);
        }

        [TestMethod]
        public void VectorLength_ValidVector_OK()
        {
            var validVector = new Vector
            {
                X = 1,
                Y = 2,
                Z = 2
            };
            var length = validVector.Length();
            Assert.AreEqual(3, length);
        }

        [TestMethod]
        public void AddTo_ValidVector_OK()
        {
            basicVector.AddTo(basicVector);
            Assert.AreEqual((0.6m, 1.2m, 1.8m), (basicVector.X, basicVector.Y, basicVector.Z));
        }

        [TestMethod]
        public void SubtractFrom_ValidVector_OK()
        {
            basicVector.SubtractFrom(basicVector);
            Assert.AreEqual((0m, 0m, 0m), (basicVector.X, basicVector.Y, basicVector.Z));
        }

        [TestMethod]
        public void ScaleUp_Zero_OK()
        {
            basicVector.ScaleUpBy(0);
            Assert.AreEqual((0m, 0m, 0m), (basicVector.X, basicVector.Y, basicVector.Z));
        }

        [TestMethod]
        public void ScaleUp_Three_OK()
        {
            basicVector.ScaleUpBy(3);
            Assert.AreEqual((0.9m, 1.8m, 2.7m), (basicVector.X, basicVector.Y, basicVector.Z));
        }

        [TestMethod]
        public void ScaleDownBy_Three_OK()
        {
            basicVector.ScaleDownBy(3);
            Assert.AreEqual((0.1m, 0.2m, 0.3m), (basicVector.X, basicVector.Y, basicVector.Z));
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void ScaleDownBy_Zero_FAIL()
        {
            basicVector.ScaleDownBy(0);
            Assert.AreEqual((0.3m, 0.6m, 0.9m), (basicVector.X, basicVector.Y, basicVector.Z));
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void UnitVector_NullVector_FAIL()
        {
            var unitVector = nullVector.Unit();
            Assert.AreEqual((0m, 0m, 0m), (unitVector.X, unitVector.Y, unitVector.Z));
        }

        [TestMethod]
        public void UnitVector_ValidVector_OK()
        {
            var newVec = new Vector
            {
                X = 2,
                Y = 0,
                Z = 0
            };
            var unitVector = newVec.Unit();
            Assert.AreEqual((1m, 0m, 0m), (unitVector.X, unitVector.Y, unitVector.Z));
        }

        [TestMethod]
        public void Dot_Product_ValidVectors_OK()
        {
            Assert.AreEqual(1.26m, basicVector.Dot(basicVector));
        }

        [TestMethod]
        public void Cross_Product_ValidVectors_OK()
        {
            var v1 = new Vector { X = 1, Y = 1, Z = 1 };
            var v2 = new Vector { X = 1, Y = 2, Z = 3 };
            var cross = v1.Cross(v2);
            Assert.AreEqual((1m, -2m, 1m), (cross.X, cross.Y, cross.Z));
        }
    }
}