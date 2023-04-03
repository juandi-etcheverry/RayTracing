using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogicTest
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void CreateNewShape_Test_OK() {
            Shape newshape = new Shape();
            Assert.IsNull(newshape.Name);
        }
    }
}
