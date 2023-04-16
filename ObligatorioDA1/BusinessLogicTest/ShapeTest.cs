using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ShapeTest
    {
        ShapeLogic shapeLogic = new ShapeLogic();
        private readonly ClientLogic clientLogic = new ClientLogic();

        [TestCleanup]
        public void RemoveAllShapes()
        {
            shapeLogic.GetShapes().Clear();
        }

        [TestMethod]
        public void AddOneShape_OK()
        {
            Shape oneShape = new Shape
            {
                Name = "Nicolas"
            };
            shapeLogic.AddShape(oneShape);
            Assert.IsTrue(shapeLogic.GetShapes().Count == 1);
        }


        [TestMethod]
        public void AddAnotherShape_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Ticu"
            };
            Shape shape2 = new Shape
            {
                Name = "Teito"
            };
            shapeLogic.AddShape(shape1);
            shapeLogic.AddShape(shape2);
            Assert.IsTrue(shapeLogic.GetShapes().Count == 2);
        }

        [TestMethod]
        public void AddShape_NotUnique_Fail()
        {
            Shape shape1 = new Shape
            {
                Name = "Esfera"
            };
            shapeLogic.AddShape(shape1);
            Assert.ThrowsException<NameException>(() => shapeLogic.AddShape(shape1));
        }

        [TestMethod]
        public void AddShapeEmptyName_Fail()
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
        public void AddShapeTrailingSpaces_Fail()
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
        public void AddShapeTrailingSpaces_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            shapeLogic.AddShape(shape1);
        }

        [TestMethod]
        public void DeleteOneShape()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            shapeLogic.AddShape(shape1);
            shapeLogic.RemoveShape(shape1);
            Assert.AreEqual(0, shapeLogic.GetShapes().Count);
        }

        [TestMethod]
        public void DeleteOneSpecificShape_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            Shape shape2 = new Shape
            {
                Name = "Mateo"
            };
            shapeLogic.AddShape(shape1);
            shapeLogic.AddShape(shape2);
            shapeLogic.RemoveShape(shape2);
            Assert.AreEqual(1, shapeLogic.GetShapes().Count);
        }

        [TestMethod]
        public void DeleteShapeNotInList_FAIL()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            shapeLogic.AddShape(shape1);
            Shape shape2 = new Shape();
            Assert.ThrowsException<NotFoundException>(() => shapeLogic.RemoveShape(shape2));
        }

        [TestMethod]
        public void RenameExistingShape_OK()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            shapeLogic.AddShape(shape1);
            shapeLogic.RenameShape(shape1, "JuanDiego");
            Assert.AreEqual("JuanDiego", shape1.Name);
        }

        [TestMethod]
        public void RenameExistingShape_FAIL()
        {
            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            shapeLogic.AddShape(shape1);
            Shape shape2 = new Shape
            {
                Name = "Mateo"
            };
            shapeLogic.AddShape(shape2);
            Assert.ThrowsException<NameException>(() => shapeLogic.RenameShape(shape1, "Mateo"));
        }

        [TestMethod]
        public void AddOneSphere_OK()
        {
            Sphere newSphere = new Sphere
            {
                Name = "Nicolas",
                Radius = 3
            };
            shapeLogic.AddShape(newSphere);
            Assert.AreEqual(1, shapeLogic.GetShapes().Count);
        }

        [TestMethod]
        public void AddSphere_NegativeRadius_FAIL()
        {
            Assert.ThrowsException<NegativeRadiusException>(() =>
            {
                Sphere newSphere = new Sphere
                {
                    Name = "Nicolas",
                    Radius = -3
                };
            });
        }

        [TestMethod]
        public void AddSphere_ValidRadius_OK()
        {
            Sphere newSphere = new Sphere()
            {
                Name = "JD",
                Radius = 2
            };
            shapeLogic.AddShape(newSphere);
            Assert.AreEqual(1, shapeLogic.GetShapes().Count);
        }

        [TestMethod]
        public void AddShape_Valid_Owner_Test_OK()
        {
            Client newClient = new Client()
            {
                Name = "Nicolas",
                Password = "ValidPass123"
            };
            clientLogic.AddClient(newClient);
            clientLogic.InitializeSession(newClient);
            
            Shape newShape = new Shape()
            {
                Name = "NewShape",
            };
            shapeLogic.AddShape(newShape);

            Assert.AreEqual(newClient, newShape.Owner);
        }


    }
}