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
    public class RayTest
    {
        private Vector _globalOrigin;
        private Vector _globalDirection;
        private Ray _globalRay;
        [TestInitialize]
        public void SetUpVectors()
        {
            _globalOrigin = new Vector()
            {
                X = 0,
                Y = 0,
                Z = 0
            };
            _globalDirection = new Vector()
            {
                X = 1,
                Y = 2,
                Z = 3,
            };
            _globalRay = new Ray()
            {
                origin = _globalOrigin,
                direction = _globalDirection
            };
        }

        [TestMethod]
        public void PointAt_ThreeUnitsForward_OK()
        {

            Vector pointingVector = _globalRay.PointAt(3);
            Assert.AreEqual((3, 6, 9), (pointingVector.X, pointingVector.Y, pointingVector.Z));
        }
    }
}
