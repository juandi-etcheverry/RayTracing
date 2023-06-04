using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ShapeTest
    {
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();

        [TestCleanup]
        public void RemoveAllShapesAndClients()
        {
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            _clientLogic.GetClients().Clear();
            _shapeLogic.GetShapes().Clear();
        }

        [TestMethod]
        public void AddOneShape_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);
            var oneShape = new Shape
            {
                ShapeName = "Nicolas"
            };
            _shapeLogic.AddShape(oneShape);
            Assert.IsTrue(_shapeLogic.GetClientShapes().Count == 1);
        }


        [TestMethod]
        public void AddAnotherShape_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Ticu"
            };
            var shape2 = new Shape
            {
                ShapeName = "Teito"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.AddShape(shape2);
            Assert.IsTrue(_shapeLogic.GetClientShapes().Count == 2);
        }

        [TestMethod]
        public void AddShape_NotUnique_Fail()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Esfera"
            };
            _shapeLogic.AddShape(shape1);
            Assert.ThrowsException<NameException>(() => _shapeLogic.AddShape(shape1));
        }

        [TestMethod]
        public void AddShapeEmptyName_Fail()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Assert.ThrowsException<NameException>(() =>
            {
                var shape1 = new Shape
                {
                    ShapeName = ""
                };
            });
        }

        [TestMethod]
        public void AddShapeTrailingSpaces_Fail()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Assert.ThrowsException<NameException>(() =>
            {
                var shape1 = new Shape
                {
                    ShapeName = "   Nicolas"
                };
            });
        }

        [TestMethod]
        public void AddShapeTrailingSpaces_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
        }

        [TestMethod]
        public void DeleteOneShape()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.RemoveShape(shape1);
            Assert.AreEqual(0, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void DeleteOneSpecificShape_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Nicolas"
            };
            var shape2 = new Shape
            {
                ShapeName = "Mateo"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.AddShape(shape2);
            _shapeLogic.RemoveShape(shape2);
            Assert.AreEqual(1, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void DeleteShapeNotInList_FAIL()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            var shape2 = new Shape();
            Assert.ThrowsException<NotFoundException>(() => _shapeLogic.RemoveShape(shape2));
        }

        [TestMethod]
        public void RenameExistingShape_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.RenameShape(shape1, "JuanDiego");
            Assert.AreEqual("JuanDiego", shape1.ShapeName);
        }

        [TestMethod]
        public void RenameExistingShape_FAIL()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape1 = new Shape
            {
                ShapeName = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            var shape2 = new Shape
            {
                ShapeName = "Mateo"
            };
            _shapeLogic.AddShape(shape2);
            Assert.ThrowsException<NameException>(() => _shapeLogic.RenameShape(shape1, "Mateo"));
        }

        [TestMethod]
        public void AddOneSphere_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var newSphere = new Sphere
            {
                ShapeName = "Nicolas",
                Radius = 3
            };
            _shapeLogic.AddShape(newSphere);
            Assert.AreEqual(1, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void AddSphere_NegativeRadius_FAIL()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Assert.ThrowsException<NonPositiveRadiusException>(() =>
            {
                var newSphere = new Sphere
                {
                    ShapeName = "Nicolas",
                    Radius = -3
                };
            });
        }

        [TestMethod]
        public void AddSphere_ValidRadius_OK()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var newSphere = new Sphere
            {
                ShapeName = "JD",
                Radius = 2
            };
            _shapeLogic.AddShape(newSphere);
            Assert.AreEqual(1, _shapeLogic.GetShapes().Count);
        }

        [TestMethod]
        public void AddShape_Valid_Owner_Test_OK()
        {
            var newClient = new Client
            {
                Name = "Nicolas",
                Password = "ValidPass123"
            };
            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);

            var newShape = new Shape
            {
                ShapeName = "NewShape"
            };
            _shapeLogic.AddShape(newShape);

            Assert.AreEqual(newClient.Name, newShape.OwnerName);
        }

        [TestMethod]
        public void AddShape_NotLogged_Test_FAIL()
        {
            var newClient = new Client
            {
                Name = "Andrew",
                Password = "VadPass12332"
            };
            _clientLogic.AddClient(newClient);

            var newShape = new Shape
            {
                ShapeName = "NewShape"
            };

            Assert.ThrowsException<SessionException>(() => _shapeLogic.AddShape(newShape));
        }

        [TestMethod]
        public void GetClientShapes_OK_Test()
        {
            var client = new Client
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);
            var oneShape = new Shape
            {
                ShapeName = "Shape1"
            };
            _shapeLogic.AddShape(oneShape);

            _clientLogic.Logout();
            var anotherClient = new Client
            {
                Name = "anotherClient",
                Password = "ValidPassword1"
            };
            _clientLogic.AddClient(anotherClient);
            _clientLogic.InitializeSession(anotherClient);
            var newShape1 = new Shape
            {
                ShapeName = "newShape1"
            };
            var newShape2 = new Shape
            {
                ShapeName = "newShape2"
            };
            _shapeLogic.AddShape(newShape1);
            _shapeLogic.AddShape(newShape2);

            Assert.AreEqual(2, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void GetShape_NotFromClient_FAIL_Test()
        {
            var client = new Client
            {
                Name = "FirstClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape = new Shape
            {
                ShapeName = "Shape"
            };
            _shapeLogic.AddShape(shape);

            _clientLogic.Logout();
            var newClient = new Client
            {
                Name = "Harry",
                Password = "ValidPass123"
            };
            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);

            Assert.ThrowsException<NotFoundException>(() => _shapeLogic.GetShape("Shape"));
        }

        [TestMethod]
        public void RemoveShape_ReferencedByModel_FAIL_Test()
        {
            var client = new Client
            {
                Name = "FirstClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            var shape = new Shape
            {
                ShapeName = "Shape"
            };
            _shapeLogic.AddShape(shape);

            var material = new Material
            {
                MaterialName = "Material",
                Color = (10, 50, 11),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material);

            var model = new Model
            {
                Name = "Model",
                Material = _materialLogic.Get("Material"),
                Shape = _shapeLogic.GetShape("Shape")
            };
            _modelLogic.Add(model);

            Assert.ThrowsException<AssociationException>(() => _shapeLogic.RemoveShape(shape));
        }
    }
}