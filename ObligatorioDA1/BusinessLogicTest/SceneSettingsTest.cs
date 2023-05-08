using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class SceneSettingsTest
    {
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly SceneSettings _sceneSettings = new SceneSettings();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private Model model;

        [TestInitialize]
        public void Setup()
        {
            Client client = new Client()
            {
                Name = "Mateo",
                Password = "Password1"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape shape = new Sphere()
            {
                Name = "shape",
                Radius = 5,
            };
            _shapeLogic.AddShape(shape);

            Material material = new Material()
            {
                Name = "NewMaterial",
                Color = (100, 54, 6),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material);

            model = new Model()
            {
                Name = "NewModel",
                Shape = shape,
                Material = material,
            };
            _modelLogic.Add(model);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _clientLogic.Logout();
            _clientLogic.GetClients().Clear();
            _sceneSettings.GetSceneSettings().Clear();
        }

        [TestMethod]
        public void Change_Scene_DefaultValues_OK_Test()
        {
            _sceneSettings.SetLookFrom(20, 20, 20);
            _sceneSettings.SetLookAt(50, 50, 50);
            _sceneSettings.SetFov(90);

            Scene scene = new Scene()
            {
                Name = "scene"
            };
            _sceneLogic.Add(scene);

            Assert.AreEqual((20, 20, 20), scene.LookFrom);
            Assert.AreEqual((50, 50, 50), scene.LookAt);
            Assert.AreEqual(90, scene.FoV);
        }
    }
}
