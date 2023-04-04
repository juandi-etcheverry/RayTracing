using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using DataHandlers;

namespace BusinessLogicTest
{
    [TestClass]
    public class ShapeTest
    {
        [TestCleanup]
        public void DataHandler_RemoveAllShapes()
        {
            DataHandler.RemoveAllShapes();
        }

        [TestMethod]
        public void DataHandler_AddOneShape_OK()
        {
            Shape oneShape = new Shape();
            DataHandler.AddShape(oneShape);
            Assert.IsTrue(DataHandler.Shapes.Count == 1);
        }


        [TestMethod]
        public void DataHandler_AddAnotherShape_OK()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Ticu";
            Shape shape2 = new Shape();
            shape2.Name = "Teito";
            DataHandler.AddShape(shape1);
            DataHandler.AddShape(shape2);
            Assert.IsTrue(DataHandler.Shapes.Count == 2);
        }

        [TestMethod]
        public void DataHandler_Unique_Fail()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Esfera";
            DataHandler.AddShape(shape1);
            Assert.ThrowsException<UniqueNameException>(() => DataHandler.AddShape(shape1));
        }

        [TestMethod]
        public void DataHandler_AddShapeEmptyName_Fail()
        {
            Shape shape1 = new Shape();
            shape1.Name = "";
            Assert.ThrowsException<EmptyNameException>(() => DataHandler.AddShape(shape1));
        }




    }
}