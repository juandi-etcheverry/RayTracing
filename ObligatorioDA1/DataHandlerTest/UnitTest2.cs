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
    }
}
