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

        [TestMethod]
        public void CreateNewShape_Name_Test_OK()
        {
            Shape newshape = new Shape();
            newshape.Name = "Nicolas";
            Assert.AreEqual("Nicolas", newshape.Name);
        }

        [TestMethod]
        public void CreateNewShape_Owner_Test_FAIL()
        {
            Shape newshape = new Shape();
            Assert.IsNotNull(newshape.Owner);
        }


    }
}
