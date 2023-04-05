using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataHandlers;
using BusinessLogic;

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
            oneShape.Name = "Nicolas";
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

        [TestMethod]
        public void DataHandler_AddShapeTrailingSpaces_Fail()
        {
            Shape shape1 = new Shape();
            shape1.Name = "   Nicolas";
            Assert.ThrowsException<TrailingSpacesNameException>(() => DataHandler.AddShape(shape1));
        }
        [TestMethod]
        public void DataHandler_AddShapeTrailingSpaces_OK()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Nicolas";
            DataHandler.AddShape(shape1);
        }

        [TestMethod]
        public void DataHandler_DeleteOneShape()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Nicolas";
            DataHandler.AddShape(shape1);
            DataHandler.DeleteShape(shape1);
            Assert.AreEqual(0, DataHandler.Shapes.Count);
        }

        [TestMethod]
        public void DataHandler_DeleteOneSpecificShape_OK()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Nicolas";
            Shape shape2 = new Shape();
            shape2.Name = "Mateo";
            DataHandler.AddShape(shape1);
            DataHandler.AddShape(shape2);
            DataHandler.DeleteShape(shape2);
            Assert.AreEqual(1, DataHandler.Shapes.Count);
        }

        [TestMethod]
        public void DataHandler_DeleteShapeNotInList_FAIL()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Nicolas";
            DataHandler.AddShape(shape1);
            Shape shape2 = new Shape();
            Assert.ThrowsException<ShapeNotInListException>(() => DataHandler.DeleteShape(shape2));
        }

        [TestMethod]
        public void DataHandler_RenameExistingShape_OK()
        {
            Shape shape1 = new Shape();
            shape1.Name = "Nicolas";
            DataHandler.AddShape(shape1);
            DataHandler.RenameShape(shape1, "Mateito");
            Assert.AreEqual("Mateito", shape1.Name);
        }





    }
}