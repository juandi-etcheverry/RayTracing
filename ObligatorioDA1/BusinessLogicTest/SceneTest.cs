using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class SceneTest
    {
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private Model _newModel;
        private Client client;

        [TestInitialize]
        public void SetUp()
        {
            client = new Client
            {
                Name = "NewName",
                Password = "ValidPassword1"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);

            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 5
            };
            _shapeLogic.AddShape(newShape);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial",
                Color = (100, 54, 6),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(newMaterial);

            _newModel = new Model
            {
                Name = "NewModel",
                Shape = newShape,
                Material = newMaterial
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
        public void AddScene_NotLogged_FAIL_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            newScene.ClientScenePreferences.LookFromDefault = (20, 10, 30);
            newScene.ClientScenePreferences.LookAtDefault = (0, 0, 15);
            newScene.ClientScenePreferences.FoVDefault = 50;
            newScene.AddPositionedModel(_newModel, (10, 10, 10));

            _clientLogic.Logout();

            Assert.ThrowsException<SessionException>(() => _sceneLogic.Add(newScene));
        }

        [TestMethod]
        public void Create_Scene_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            newScene.ClientScenePreferences.LookFromDefault = (20, 10, 30);
            newScene.ClientScenePreferences.LookAtDefault = (0, 0, 15);
            newScene.ClientScenePreferences.FoVDefault = 50;
            newScene.AddPositionedModel(_newModel, (10, 10, 10));

            _sceneLogic.Add(newScene);

            Assert.AreEqual(1, _sceneLogic.GetClientScenes().Count);
        }

        [TestMethod]
        public void Create_Scene_RegistrationDate_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            newScene.ClientScenePreferences.LookFromDefault = (20, 10, 30);
            newScene.ClientScenePreferences.LookAtDefault = (0, 0, 15);
            newScene.ClientScenePreferences.FoVDefault = 50;
            Assert.AreEqual(DateTime.Now, newScene.RegistrationDate);
        }

        [TestMethod]
        public void Scene_EmptyName_FAIL_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var newScene = new Scene
                {
                    SceneName = ""
                };
            });
        }

        [TestMethod]
        public void AddScene_RepeatedScenes_FAIL_Test()
        {
            var oneScene = new Scene
            {
                SceneName = "SameName"
            };
            oneScene.ClientScenePreferences.LookFromDefault = (20, 10, 30);
            oneScene.ClientScenePreferences.LookAtDefault = (0, 0, 15);
            oneScene.ClientScenePreferences.FoVDefault = 50;
            oneScene.AddPositionedModel(_newModel, (10, 10, 30));
            _sceneLogic.Add(oneScene);

            var anotherScene = new Scene
            {
                SceneName = "SameName"
            };
            anotherScene.ClientScenePreferences.LookFromDefault = (20, 10, 30);
            anotherScene.ClientScenePreferences.LookAtDefault = (0, 0, 15);
            anotherScene.ClientScenePreferences.FoVDefault = 50;
            oneScene.AddPositionedModel(_newModel, (40, 0, 30));

            Assert.ThrowsException<NameException>(() => _sceneLogic.Add(anotherScene));
        }

        [TestMethod]
        public void Scene_NameTrailingSpaces_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var anotherScene = new Scene
                {
                    SceneName = "  Invalid MaterialName"
                };
            });
        }

        [TestMethod]
        public void Delete_PositionedModel_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            var positionedModel = newScene.AddPositionedModel(_newModel, (10, 10, 10));

            _sceneLogic.Add(newScene);

            newScene.DeletePositionedModel(positionedModel.Name, positionedModel.Coordinates);

            Assert.AreEqual(0, newScene.Models.Count);
        }

        [TestMethod]
        public void ModifyScene_GetLastModificationDate_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            var positionedModel = newScene.AddPositionedModel(_newModel, (10, 10, 10));

            _sceneLogic.Add(newScene);

            newScene.DeletePositionedModel(positionedModel.Name, positionedModel.Coordinates);

            Assert.AreEqual(DateTime.Now, newScene.LastModificationDate);
        }

        [TestMethod]
        public void CreateScene_EmptyLookFrom_DefaultValue_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            Assert.AreEqual((0, 2, 0), newScene.ClientScenePreferences.LookFromDefault);
        }

        [TestMethod]
        public void CreateScene_EmptyLookAt_DefaultValue_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            Assert.AreEqual((0, 2, 5), newScene.ClientScenePreferences.LookAtDefault);
        }

        [TestMethod]
        public void CreateScene_EmptyFoV_DefaultValue_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            Assert.AreEqual((uint)30, newScene.ClientScenePreferences.FoVDefault);
        }

        [TestMethod]
        public void CreateScene_OutOfRangeFoV_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var newScene = new Scene
                {
                    SceneName = "NewScene"
                };
                newScene.ClientScenePreferences.FoVDefault = 200;
            });
        }

        [TestMethod]
        public void Scenes_OrderByModificationDateDescending_OK_Test()
        {
            var firstScene = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(firstScene);

            var secondScene = new Scene
            {
                SceneName = "NewScene2"
            };
            _sceneLogic.Add(secondScene);

            firstScene.LastModificationDate = DateTime.Today.AddDays(-1);

            Assert.AreEqual("NewScene2", _sceneLogic.GetClientScenes()[0].SceneName);
        }

        [TestMethod]
        public void DeleteScene_OK_Test()
        {
            var scene = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(scene);

            _sceneLogic.RemoveScene(scene);

            Assert.AreEqual(0, _sceneLogic.GetClientScenes().Count);
            Assert.AreEqual(1, _modelLogic.GetClientModels().Count);
            Assert.AreEqual(1, _shapeLogic.GetClientShapes().Count);
            Assert.AreEqual(1, _materialLogic.GetClientMaterials().Count);
        }

        [TestMethod]
        public void DeleteSceneNotInList_FAIL_Test()
        {
            var scene = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(scene);
            _sceneLogic.RemoveScene(scene);

            Assert.ThrowsException<NotFoundException>(() => _sceneLogic.RemoveScene(scene));
        }

        [TestMethod]
        public void GetScene_NotExist_FAIL_Test()
        {
            var scene = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(scene);

            Assert.ThrowsException<NotFoundException>(() => _sceneLogic.GetScene("NewScene2"));
        }

        [TestMethod]
        public void RenameScene_OK_Test()
        {
            var scene = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(scene);

            _sceneLogic.RenameScene(_sceneLogic.GetScene("newScene1"), "NewScene2");

            Assert.AreEqual("NewScene2", scene.SceneName);
        }

        [TestMethod]
        public void RenameScene_NotExist_FAIL_Test()
        {
            var scene = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(scene);

            Assert.ThrowsException<NotFoundException>(() =>
                _sceneLogic.RenameScene(_sceneLogic.GetScene("newScene2"), "NewScene3"));
        }

        [TestMethod]
        public void RenameScene_NameAlreadyExists_FAIL_Test()
        {
            var scene1 = new Scene
            {
                SceneName = "NewScene1"
            };
            _sceneLogic.Add(scene1);
            var scene2 = new Scene
            {
                SceneName = "NewScene2"
            };
            _sceneLogic.Add(scene2);

            Assert.ThrowsException<NameException>(() =>
                _sceneLogic.RenameScene(_sceneLogic.GetScene("NewScene1"), "NewScene2"));
        }

        [TestMethod]
        public void Change_Scene_DefaultValues_OK_Test()
        {
            client.ClientScenePreferences.LookFromDefault = (1, 1, 1);
            client.ClientScenePreferences.LookAtDefault = (1, 1, 1);
            client.ClientScenePreferences.FoVDefault = 1;

            var scene = new Scene
            {
                SceneName = "scene"
            };
            _sceneLogic.Add(scene);

            Assert.AreEqual((1, 1, 1), scene.ClientScenePreferences.LookFromDefault);
            Assert.AreEqual((1, 1, 1), scene.ClientScenePreferences.LookAtDefault);
            Assert.AreEqual((uint)1, scene.ClientScenePreferences.FoVDefault);
        }

        [TestMethod]
        public void DefaultValues_OK_Test()
        {
            var scene = new Scene
            {
                SceneName = "Scene"
            };
            _sceneLogic.Add(scene);

            Assert.AreEqual((0, 2, 0), scene.ClientScenePreferences.LookFromDefault);
            Assert.AreEqual((0, 2, 5), scene.ClientScenePreferences.LookAtDefault);
            Assert.AreEqual((uint)30, scene.ClientScenePreferences.FoVDefault);
        }

        [TestMethod]
        public void Change_Scene_Default_And_FoV_Value_OK_Test()
        {
            client.ClientScenePreferences.FoVDefault = 10;
            var scene = new Scene
            {
                SceneName = "Scene"
            };
            _sceneLogic.Add(scene);
            scene.ClientScenePreferences.FoVDefault = 90;

            Assert.AreEqual((uint)90, scene.ClientScenePreferences.FoVDefault);
        }

        [TestMethod]
        public void Change_Scene_Default_LogOut_LogIN_OK_Test()
        {
            client.ClientScenePreferences.FoVDefault = 10;
            _clientLogic.Logout();
            _clientLogic.InitializeSession(client);

            Assert.AreEqual((uint)10, client.ClientScenePreferences.FoVDefault);
        }

        [TestMethod]
        public void GetLastRenderDate_NewScene_OK_Test()
        {
            var scene = new Scene()
            {
                SceneName = "Scene"
            };
            _sceneLogic.Add(scene);

            Assert.AreEqual(DateTime.MinValue, scene.LastRenderDate);
        }

        [TestMethod]
        public void GetPositionedModel_Scene_OK_Test()
        {
            var scene = new Scene()
            {
                SceneName = "Scene"
            };
            _sceneLogic.Add(scene);

            var positionedModel = scene.AddPositionedModel(_newModel, (1, 1, 2));

            Assert.AreEqual(positionedModel, scene.GetPositionedModel(_newModel.Name, (1, 1, 2)));
        }
    }
}