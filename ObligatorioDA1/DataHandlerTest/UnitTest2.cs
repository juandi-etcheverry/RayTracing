using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataHandlers;
using BusinessLogic;

namespace DataHandlerTest
{
    [TestClass]
    public class ShapeTest
    {

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
            Shape shape1= new Shape();
            Shape shape2 = new Shape();
            DataHandler.AddShape(shape1);
            DataHandler.AddShape(shape2);
            Assert.IsTrue(DataHandler.Shapes.Count == 2);
        }

        
    }
}
