using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ShapeTest
    {
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();

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
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);
            Shape oneShape = new Shape
            {
                Name = "Nicolas"
            };
            _shapeLogic.AddShape(oneShape);
            Assert.IsTrue(_shapeLogic.GetClientShapes().Count == 1);
        }


        [TestMethod]
        public void AddAnotherShape_OK()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Ticu"
            };
            Shape shape2 = new Shape
            {
                Name = "Teito"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.AddShape(shape2);
            Assert.IsTrue(_shapeLogic.GetClientShapes().Count == 2);
        }

        [TestMethod]
        public void AddShape_NotUnique_Fail()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Esfera"
            };
            _shapeLogic.AddShape(shape1);
            Assert.ThrowsException<NameException>(() => _shapeLogic.AddShape(shape1));
        }

        [TestMethod]
        public void AddShapeEmptyName_Fail()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

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
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

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
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
        }

        [TestMethod]
        public void DeleteOneShape()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.RemoveShape(shape1);
            Assert.AreEqual(0, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void DeleteOneSpecificShape_OK()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            Shape shape2 = new Shape
            {
                Name = "Mateo"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.AddShape(shape2);
            _shapeLogic.RemoveShape(shape2);
            Assert.AreEqual(1, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void DeleteShapeNotInList_FAIL()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            Shape shape2 = new Shape();
            Assert.ThrowsException<NotFoundException>(() => _shapeLogic.RemoveShape(shape2));
        }

        [TestMethod]
        public void RenameExistingShape_OK()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            _shapeLogic.RenameShape(shape1, "JuanDiego");
            Assert.AreEqual("JuanDiego", shape1.Name);
        }

        [TestMethod]
        public void RenameExistingShape_FAIL()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape1 = new Shape
            {
                Name = "Nicolas"
            };
            _shapeLogic.AddShape(shape1);
            Shape shape2 = new Shape
            {
                Name = "Mateo"
            };
            _shapeLogic.AddShape(shape2);
            Assert.ThrowsException<NameException>(() => _shapeLogic.RenameShape(shape1, "Mateo"));
        }

        [TestMethod]
        public void AddOneSphere_OK()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Sphere newSphere = new Sphere
            {
                Name = "Nicolas",
                Radius = 3
            };
            _shapeLogic.AddShape(newSphere);
            Assert.AreEqual(1, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void AddSphere_NegativeRadius_FAIL()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Assert.ThrowsException<NonPositiveRadiusException>(() =>
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
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Sphere newSphere = new Sphere()
            {
                Name = "JD",
                Radius = 2
            };
            _shapeLogic.AddShape(newSphere);
            Assert.AreEqual(1, _shapeLogic.GetShapes().Count);
        }

        [TestMethod]
        public void AddShape_Valid_Owner_Test_OK()
        {
            Client newClient = new Client()
            {
                Name = "Nicolas",
                Password = "ValidPass123"
            };
            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);
            
            Shape newShape = new Shape()
            {
                Name = "NewShape",
            };
            _shapeLogic.AddShape(newShape);

            Assert.AreEqual(newClient.Name, newShape.OwnerName);
        }

        [TestMethod]
        public void AddShape_NotLogged_Test_FAIL()
        {
            Client newClient = new Client()
            {
                Name = "Andrew",
                Password = "VadPass12332"
            };
            _clientLogic.AddClient(newClient);

            Shape newShape = new Shape()
            {
                Name = "NewShape",
            };

            Assert.ThrowsException<SessionException>(() => _shapeLogic.AddShape(newShape));
        }

        [TestMethod]
        public void GetClientShapes_OK_Test()
        {
            Client client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);
            Shape oneShape = new Shape
            {
                Name = "Shape1"
            };
            _shapeLogic.AddShape(oneShape);

            _clientLogic.Logout();
            Client anotherClient = new Client()
            {
                Name = "anotherClient",
                Password = "ValidPassword1"
            };
            _clientLogic.AddClient(anotherClient);
            _clientLogic.InitializeSession(anotherClient);
            Shape newShape1 = new Shape
            {
                Name = "newShape1"
            };
            Shape newShape2 = new Shape
            {
                Name = "newShape2"
            };
            _shapeLogic.AddShape(newShape1);
            _shapeLogic.AddShape(newShape2);

            Assert.AreEqual(2, _shapeLogic.GetClientShapes().Count);
        }

        [TestMethod]
        public void GetShape_NotFromClient_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "FirstClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape = new Shape()
            {
                Name = "Shape",
            };
            _shapeLogic.AddShape(shape);

            _clientLogic.Logout();
            Client newClient = new Client()
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
            Shape shape = new Shape()
            {
                Name = "Shape",
            };
            _shapeLogic.AddShape(shape);

            Material material = new Material()
            {
                Name = "Material",
                Color = (10, 50, 11),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material);

            Model model = new Model()
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