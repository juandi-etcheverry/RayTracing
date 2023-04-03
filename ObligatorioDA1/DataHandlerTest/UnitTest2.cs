using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataHandler;
using BusinessLogic;

namespace DataHandlerTest
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void CreateDataHandler_Test_Is_Not_Null_OK()
        {
            DataHandlerClass dataHandler = new DataHandlerClass();
            Assert.IsNotNull(dataHandler);
        }

        [TestMethod]
        public void DataHandler_AddOneShape_OK()
        {
            DataHandlerClass dataHandler = new DataHandlerClass();
            Shape oneShape = new Shape();
            dataHandler.AddShape(oneShape);

            Assert.IsTrue(dataHandler.Shapes.count == 1);
        }
    }
}
