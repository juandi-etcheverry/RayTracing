using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInDB;

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
            };
            newMaterial.SetColor(100, 54, 6);
            _materialLogic.Add(newMaterial);

            _newModel = new Model
            {
                ModelName = "NewModel",
                Shape = newShape,
                Material = newMaterial
            };
            _modelLogic.Add(_newModel);
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            ClearDatabase.ClearAll();
        }

        [TestMethod]
        public void AddScene_NotLogged_FAIL_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            newScene.ClientScenePreferences.SetLookFromDefault((20, 10, 30));
            newScene.ClientScenePreferences.SetLookAtDefault((0, 0, 15));
            newScene.ClientScenePreferences.FoVDefault = 50;

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
            newScene.ClientScenePreferences.SetLookFromDefault((20, 10, 30));
            newScene.ClientScenePreferences.SetLookAtDefault((0, 0, 15));
            newScene.ClientScenePreferences.FoVDefault = 50;

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
            newScene.ClientScenePreferences.SetLookFromDefault((20, 10, 30));
            newScene.ClientScenePreferences.SetLookAtDefault((0, 0, 15));
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
            oneScene.ClientScenePreferences.SetLookFromDefault((20, 10, 30));
            oneScene.ClientScenePreferences.SetLookAtDefault((0, 0, 15));
            oneScene.ClientScenePreferences.FoVDefault = 50;
            _sceneLogic.Add(oneScene);

            var anotherScene = new Scene
            {
                SceneName = "SameName"
            };
            anotherScene.ClientScenePreferences.SetLookFromDefault((20, 10, 30));
            anotherScene.ClientScenePreferences.SetLookAtDefault((0, 0, 15));
            anotherScene.ClientScenePreferences.FoVDefault = 50;
            //_sceneLogic.AddPositionedModel(_newModel, (40, 0, 30), anotherScene.Id);

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
        public void ModifyScene_GetLastModificationDate_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            var positionedModel = _sceneLogic.AddPositionedModel(_newModel, (10, 10, 10), newScene.Id);

            _sceneLogic.DeletePositionedModel(positionedModel.Id, newScene.Id);

            TimeSpan toleranceSpan = TimeSpan.FromSeconds(5);
            Assert.IsTrue((newScene.LastModificationDate - DateTime.Now) < toleranceSpan);
        }

        [TestMethod]
        public void CreateScene_EmptyLookFrom_DefaultValue_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            Assert.AreEqual((0, 2, 0), newScene.ClientScenePreferences.GetLookFromDefault());
        }

        [TestMethod]
        public void CreateScene_EmptyLookAt_DefaultValue_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            Assert.AreEqual((0, 2, 5), newScene.ClientScenePreferences.GetLookAtDefault());
        }

        [TestMethod]
        public void CreateScene_EmptyFoV_DefaultValue_OK_Test()
        {
            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            Assert.AreEqual(30, newScene.ClientScenePreferences.FoVDefault);
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

            _sceneLogic.RenameScene(scene, "NewScene2");

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
        public void DefaultValues_OK_Test()
        {
            var scene = new Scene
            {
                SceneName = "Scene"
            };
            _sceneLogic.Add(scene);

            Assert.AreEqual((0, 2, 0), scene.ClientScenePreferences.GetLookFromDefault());
            Assert.AreEqual((0, 2, 5), scene.ClientScenePreferences.GetLookAtDefault());
            Assert.AreEqual(30, scene.ClientScenePreferences.FoVDefault);
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

            Assert.AreEqual(90, scene.ClientScenePreferences.FoVDefault);
        }

        [TestMethod]
        public void Change_Scene_Default_LogOut_LogIN_OK_Test()
        {
            client.ClientScenePreferences.FoVDefault = 10;
            _clientLogic.Logout();
            _clientLogic.InitializeSession(client);

            Assert.AreEqual(10, client.ClientScenePreferences.FoVDefault);
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

            var positionedModel = _sceneLogic.AddPositionedModel(_newModel, (1, 1, 2), scene.Id);

            Assert.AreEqual(positionedModel.Id, _sceneLogic.GetPositionedModel(scene, positionedModel.Id).Id);
        }
    }
}