﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataHandlers;
using BusinessLogicExceptions;
using System.Security.Cryptography;
using Domain;

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
            Shape oneShape = new Shape
            {
                Name = "Nicolas"
            };
            DataHandler.AddShape(oneShape);
            Assert.IsTrue(DataHandler.Shapes.Count == 1);
        }


        [TestMethod]
        public void DataHandler_AddAnotherShape_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Ticu"
            };
            Shape shape2 = new Shape
            {
                Name = "Teito"
            };
            DataHandler.AddShape(shape1);
            DataHandler.AddShape(shape2);
            Assert.IsTrue(DataHandler.Shapes.Count == 2);
        }

        [TestMethod]
        public void DataHandler_Unique_Fail()
        {
            Shape shape1 = new Shape
            {
                Name = "Esfera"
            };
            DataHandler.AddShape(shape1);
            Assert.ThrowsException<NameException>(() => DataHandler.AddShape(shape1));
        }

        [TestMethod]
        public void DataHandler_AddShapeEmptyName_Fail()
        {
            
            Assert.ThrowsException<NameException>(() =>
            {
                Shape shape1 = new Shape
                {
                    Name = ""
                };
            });
        }

        [TestMethod]
        public void DataHandler_AddShapeTrailingSpaces_Fail()
        {
            
            Assert.ThrowsException<NameException>(() =>
            {
                Shape shape1 = new Shape
                {
                    Name = "   Nicolas"
                };
            });
        }
        [TestMethod]
        public void DataHandler_AddShapeTrailingSpaces_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            DataHandler.AddShape(shape1);
        }

        [TestMethod]
        public void DataHandler_DeleteOneShape()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            DataHandler.AddShape(shape1);
            DataHandler.DeleteShape(shape1);
            Assert.AreEqual(0, DataHandler.Shapes.Count);
        }

        [TestMethod]
        public void DataHandler_DeleteOneSpecificShape_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            Shape shape2 = new Shape
            {
                Name = "Mateo"
            };
            DataHandler.AddShape(shape1);
            DataHandler.AddShape(shape2);
            DataHandler.DeleteShape(shape2);
            Assert.AreEqual(1, DataHandler.Shapes.Count);
        }

        [TestMethod]
        public void DataHandler_DeleteShapeNotInList_FAIL()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            DataHandler.AddShape(shape1);
            Shape shape2 = new Shape();
            Assert.ThrowsException<NotFoundException>(() => DataHandler.DeleteShape(shape2));
        }

        [TestMethod]
        public void DataHandler_RenameExistingShape_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            DataHandler.AddShape(shape1);
            DataHandler.RenameShape(shape1, "JuanDiego");
            Assert.AreEqual("JuanDiego", shape1.Name);
        }

        [TestMethod]
        public void DataHandler_RenameExistingShape_FAIL()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            DataHandler.AddShape(shape1);
            Shape shape2 = new Shape
            {
                Name = "Mateo"
            };
            DataHandler.AddShape(shape2);
            Assert.ThrowsException<NameException>(()=> DataHandler.RenameShape(shape1, "Mateo"));
        }

        [TestMethod]
        public void DataHandler_AddOneSphere_OK()
        {
            Sphere newSphere = new Sphere
            {
                Name = "Nicolas",
                Radius = 3
            };
            DataHandler.AddShape(newSphere);
            Assert.AreEqual(1, DataHandler.Shapes.Count);
        }

        [TestMethod]
        public void DataHandler_AddSphere_NegativeRadius_FAIL()
        {
            Sphere newSphere = new Sphere
            {
                Name = "Nicolas",
                Radius = -3
            };
            Assert.ThrowsException<NegativeRadiusException>(() => DataHandler.AddShape(newSphere));
        }

        [TestMethod]
        public void DataHandler_AddSphere_ValidRadius_OK()
        {
            Sphere newSphere = new Sphere()
            {
                Name = "JD",
                Radius = 2
            };
            DataHandler.AddShape(newSphere);
            Assert.AreEqual(1, DataHandler.Shapes.Count);
        }

    }
}