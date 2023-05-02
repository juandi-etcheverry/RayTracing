using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
using Domain;
using BusinessLogic;

namespace BusinessLogicTest
{
    [TestClass]
    public class SceneTest
    {
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private Model _newModel;

        [TestInitialize]
        public void SetUp()
        {
            Client newClient = new Client()
            {
                Name = "NewName",
                Password = "ValidPassword1"
            };
            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);

            Shape newShape = new Sphere()
            {
                Name = "NewSphere",
                Radius = 5,
            };
            _shapeLogic.AddShape(newShape);

            Material newMaterial = new Material()
            {
                Name = "NewMaterial",
                Color = (100, 54, 6),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(newMaterial);

            _newModel = new Model()
            {
                Name = "NewModel",
                Shape = newShape,
                Material = newMaterial,
            };
            _modelLogic.Add(_newModel);

        }

        [TestCleanup]
        public void CleanUpTests()
        {
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            _clientLogic.GetClients().Clear();
            _shapeLogic.GetShapes().Clear();
            _materialLogic.GetAll().Clear();
            _modelLogic.GetAll().Clear();
            _sceneLogic.GetAll().Clear();
        }

        [TestMethod]
        public void Create_Scene_OK_Test()
        {
            Scene newScene = new Scene()
            {
                Name = "NewScene",
                LookFrom = (20, 10, 30),
                LookAt = (0, 0, 15),
                FoV = 50
            };
            newScene.AddPositionedModel(_newModel, (10, 10, 10));

            _sceneLogic.Add(newScene);

            Assert.AreEqual(1, _sceneLogic.GetClientScenes().Count);
        }
    }
}
