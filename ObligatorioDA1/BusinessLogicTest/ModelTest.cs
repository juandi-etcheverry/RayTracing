using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
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

        [TestInitialize]
        public void CreateAndInitializeClient()
        {
            _client = new Client()
            {
                Name = "NewClient",
                Password = "NewPassword1"
            };

            _clientLogic.AddClient(_client);
            _clientLogic.InitializeSession(_client);
        }

        [TestInitialize]
        public void AddShapes()
        {
            Shape sphere1 = new Sphere()
            {
                Name = "New Sphere 1",
                Radius = 3
            };
            Shape sphere2 = new Sphere()
            {
                Name = "New Sphere 1",
                Radius = 3
            };

            _shapeLogic.AddShape(sphere1);
            _shapeLogic.AddShape(sphere2);
        }

        [TestInitialize]
        public void AddMaterials()
        {
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
    }
}
