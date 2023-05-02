﻿using BusinessLogic;
using BusinessLogicExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class ModelTest
    {
        private Client _client;
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();

        [TestInitialize]
        public void LoginClients_CreateShapes_Create_Materials()
        {
            _client = new Client()
            {
                Name = "NewClient",
                Password = "NewPassword1"
            };
            _clientLogic.AddClient(_client);
            _clientLogic.InitializeSession(_client);

            Shape sphere1 = new Sphere()
            {
                Name = "New Sphere 1",
                Radius = 3
            };
            Shape sphere2 = new Sphere()
            {
                Name = "New Sphere 2",
                Radius = 3
            };
            _shapeLogic.AddShape(sphere1);
            _shapeLogic.AddShape(sphere2);

            Material material1 = new Material()
            {
                Name = "New Material 1",
                Color = (0, 0, 0),
                Type = MaterialType.Lambertian
            };
            Material material2 = new Material()
            {
                Name = "New Material 2",
                Color = (190, 2, 42),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material1);
            _materialLogic.Add(material2);
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            _clientLogic.GetClients().Clear();
            _shapeLogic.GetShapes().Clear();
            _materialLogic.GetAll().Clear();
            _modelLogic.GetAll().Clear();
        }


        [TestMethod]
        public void Model_ValidMaterial_OK_Test()
        {
            Model model = new Model()
            {
                Name = "New Model",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };

            Assert.AreEqual("New Model", model.Name);
        }

        [TestMethod]
        public void AddModel_Valid_Owner_Test_OK()
        {
            Model model = new Model()
            {
                Name = "Modelius",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _modelLogic.Add(model);

            Assert.AreEqual(_client.Name, model.OwnerName);
        }

        [TestMethod]
        public void AddModel_NotLogged_Test_FAIL()
        {
            Model model = new Model()
            {
                Name = "Modelius",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _clientLogic.Logout();

            Assert.ThrowsException<SessionException>(() => _modelLogic.Add(model));
        }

        [TestMethod]
        public void Model_EmptyName_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                Model model = new Model()
                {
                    Name = "",
                    Shape = _shapeLogic.GetShape("New Sphere 1"),
                    Material = _materialLogic.Get("New Material 1")
                };
            });
        }

        [TestMethod]
        public void Model_NameTrailingSpaces_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                Model model = new Model()
                {
                    Name = " Incorrect Model",
                    Shape = _shapeLogic.GetShape("New Sphere 1"),
                    Material = _materialLogic.Get("New Material 1")
                };
            });
        }

        [TestMethod]
        public void AddModel_RepeatedModels_FAIL_Test()
        {
            Model model1 = new Model()
            {
                Name = "ModEl 1",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            Model model2 = new Model()
            {
                Name = "model 1",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _modelLogic.Add(model1);

            Assert.ThrowsException<NameException>(() => _modelLogic.Add(model2));
        }

        [TestMethod]
        public void RenameModel_OK_Test()
        {
            Model model = new Model()
            {
                Name = "model 1",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _modelLogic.Add(model);
            _modelLogic.Rename(model, "Azucar");
            Assert.AreEqual(_modelLogic.Get("Azucar"), model);
        }

        [TestMethod]
        public void RenameModel_InvalidMaterial_FAIL_Test()
        {
            Model model = new Model()
            {
                Name = "model 1",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };

            Assert.ThrowsException<NotFoundException>(() =>
            {
                _modelLogic.Rename(model, "Balid Blue");
            });
        }

        [TestMethod]
        public void RenameModel_NameInUse_FAIL_Test()
        {
            Model model1 = new Model()
            {
                Name = "model 1",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            Model model2 = new Model()
            {
                Name = "model 2",
                Shape = _shapeLogic.GetShape("New Sphere 2"),
                Material = _materialLogic.Get("New Material 2")
            };

            _modelLogic.Add(model1);
            _modelLogic.Add(model2);

            Assert.ThrowsException<NameException>(() => _modelLogic.Rename(model2, "model 1"));
        }

        [TestMethod]
        public void AddModel_SameName_DifferentOwner_Test_OK()
        {
            Model model1 = new Model()
            {
                Name = "SameNameModel",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _modelLogic.Add(model1);

            _clientLogic.Logout();
            Client anotherClient = new Client()
            {
                Name = "HarryPotter",
                Password = "ValidPassWord1233"
            };
            _clientLogic.AddClient(anotherClient);
            _clientLogic.InitializeSession(anotherClient);

            Shape sphere2 = new Sphere()
            {
                Name = "Sphere2",
                Radius = 3
            };
            _shapeLogic.AddShape(sphere2);

            Material material2 = new Material()
            {
                Name = "Material2",
                Color = (190, 2, 42),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material2);

            Model model2 = new Model()
            {
                Name = "SameNameModel",
                Shape = _shapeLogic.GetShape("Sphere2"),
                Material = _materialLogic.Get("Material2")
            };
            _modelLogic.Add(model2);


            Assert.AreEqual(1, _modelLogic.GetClientModels().Count);
        }

        [TestMethod]
        public void RemoveModel_OK_Test()
        {
            Model model = new Model()
            {
                Name = "SameNameModel",
                Shape = _shapeLogic.GetShape("New Sphere 2"),
                Material = _materialLogic.Get("New Material 1")
            };
            _modelLogic.Add(model);
            _modelLogic.Remove(model);
            Assert.AreEqual(0, _modelLogic.GetClientModels().Count);
        }

        [TestMethod]
        public void RemoveModel_NonExistant_FAIL_Test()
        {
            Model model = new Model()
            {
                Name = "ModelName",
                Shape = _shapeLogic.GetShape("New Sphere 2"),
                Material = _materialLogic.Get("New Material 1")
            };
            Assert.ThrowsException<NotFoundException>(() => _modelLogic.Remove(model));
        }

        [TestMethod]
        public void GetClientModels_OK_Test()
        {
            Model model1 = new Model()
            {
                Name = "ModelName1",
                Shape = _shapeLogic.GetShape("New Sphere 2"),
                Material = _materialLogic.Get("New Material 1")
            };
            Model model2 = new Model()
            {
                Name = "ModelName2",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 2")
            };
            _modelLogic.Add(model1);
            _modelLogic.Add(model2);

            _clientLogic.Logout();
            Client newClient = new Client()
            {
                Name = "Spiderman",
                Password = "ValidPassWord1233"
            };
            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);

            Shape newShape = new Sphere()
            {
                Name = "newShape",
                Radius = 3
            };
            _shapeLogic.AddShape(newShape);
            Material newMaterial = new Material()
            {
                Name = "newMaterial",
                Color = (10, 2, 154),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(newMaterial);

            Model newModel = new Model()
            {
                Name = "newModel",
                Shape = _shapeLogic.GetShape("newShape"),
                Material = _materialLogic.Get("newMaterial")
            };
            _modelLogic.Add(newModel);

            Assert.AreEqual(1, _modelLogic.GetClientModels().Count);
        }
    }
}