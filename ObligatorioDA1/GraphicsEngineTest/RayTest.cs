using GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphicsEngineTest
{
    [TestClass]
    public class RayTest
    {
        private Vector _globalDirection;
        private Vector _globalOrigin;
        private Ray _globalRay;

        [TestInitialize]
        public void SetUpVectors()
        {
            _globalOrigin = new Vector
            {
                X = 0,
                Y = 0,
                Z = 0
            };
            _globalDirection = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            _globalRay = new Ray
            {
                Origin = _globalOrigin,
                Direction = _globalDirection
            };
        }

        [TestMethod]
        public void PointAt_ThreeUnitsForward_OK()
        {
            var pointingVector = _globalRay.PointAt(3);
            Assert.AreEqual((3, 6, 9), (pointingVector.X, pointingVector.Y, pointingVector.Z));
        }
    }
}