using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
                x = 0.3,
                y = 1.0,
                z = 0.0
            };

            Assert.AreEqual((0, 3, 1.0, 0.0), (v.x, v.y, v.z));
        }
    }
}
