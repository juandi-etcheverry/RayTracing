using System;
using System.Linq;
using BusinessLogic;
using Domain;
using GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInDB;

namespace GraphicsEngineTest
{
    [TestClass]
    public class GraphicsEngineTest
    {
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly RenderLogLogic _renderLogLogic = new RenderLogLogic();

        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();

        [TestInitialize]
        public void SetUp()
        {
            ClearDatabase.ClearAll();
            var newClient = new Client
            {
                Name = "NewClient3",
                Password = "TicuEsUnGenio1"
            };
            newClient.ClientScenePreferences.SetLookAtDefault((10, 10, 10));
            newClient.ClientScenePreferences.SetLookFromDefault((20, 30, 1));
            newClient.ClientScenePreferences.FoVDefault = 50;

            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);
        }

        [TestCleanup]
        public void ResetRandom()
        {
            RandomGenerator.ShowDefaultValue = false;
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            ClearDatabase.ClearAll();
        }

        [TestMethod]
        public void Render_EarthWithBall_OK()
        {
            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 1
            };
            _shapeLogic.AddShape(newShape);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(230, 15, 160);
            _materialLogic.Add(newMaterial);

            var newModel = new Model
            {
                ModelName = "NewModel",
                Shape = _shapeLogic.GetShape(newShape.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel);

            var newScene = new Scene
            {
                SceneName = "new scene"
            };
            _sceneLogic.Add(newScene);

            newScene.ClientScenePreferences.SetLookAtDefault((0, 2, 5));
            newScene.ClientScenePreferences.SetLookFromDefault((0, 2, 0));
            newScene.ClientScenePreferences.FoVDefault = 30;

            var sceneContext = _sceneLogic.Update(newScene);

            var newModelContext = _modelLogic.Get(newModel.ModelName);

            _sceneLogic.AddPositionedModel(newModelContext, (0, 2, 8), sceneContext.Id);

            var grass = new Material
            {
                MaterialName = "Grass"
            };
            grass.SetColor(14, 255, 0);
            _materialLogic.Add(grass);

            Shape globe = new Sphere
            {
                ShapeName = "Earth",
                Radius = 2000
            };
            _shapeLogic.AddShape(globe);

            var globeModel = new Model
            {
                Material = _materialLogic.Get(grass.MaterialName),
                Shape = _shapeLogic.GetShape(globe.ShapeName),
                ModelName = "Globe",
                WantPreview = false
            };
            _modelLogic.Add(globeModel);

            var globeModelContext = _modelLogic.Get(globeModel.ModelName);

            _sceneLogic.AddPositionedModel(globeModelContext, (0, -1999, 8), sceneContext.Id);

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var updatedScene = _sceneLogic.GetScene(sceneContext.Id);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 12
            };
            var result = engine.Render();
            var TrueImage =
                "P3\n12 8\n255\n178 209 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n178 209 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n181 210 255\n181 210 255\n181 210 255\n181 210 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n130 11 160\n130 11 160\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n189 216 255\n189 216 255\n189 216 255\n189 215 255\n158 12 160\n159 12 160\n159 12 160\n158 12 160\n189 215 255\n189 216 255\n189 216 255\n189 216 255\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n6 11 0\n6 11 0\n6 11 0\n6 11 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n0 1 0\n0 1 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n";
            Assert.AreEqual(TrueImage, result.parser.Parse());
        }

        [TestMethod]
        public void Render_EmptyScene_OK()
        {
            var newScene = new Scene
            {
                SceneName = "new scene"
            };
            _sceneLogic.Add(newScene);
            newScene.ClientScenePreferences.SetLookAtDefault((0, 2, 5));
            newScene.ClientScenePreferences.SetLookFromDefault((0, 2, 0));
            newScene.ClientScenePreferences.FoVDefault = 30;

            var updatedScene = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();
            var BlueSkies =
                "P3\n12 8\n255\n178 209 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n178 209 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n181 210 255\n181 210 255\n181 210 255\n181 210 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n189 216 255\n189 216 255\n189 216 255\n189 215 255\n189 215 255\n189 215 255\n189 215 255\n189 215 255\n189 215 255\n189 216 255\n189 216 255\n189 216 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n197 220 255\n197 220 255\n197 220 255\n198 221 255\n198 221 255\n198 221 255\n198 221 255\n198 221 255\n198 221 255\n197 220 255\n197 220 255\n197 220 255\n201 223 255\n201 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n201 223 255\n201 223 255\n205 225 255\n205 225 255\n205 225 255\n206 225 255\n206 225 255\n206 225 255\n206 225 255\n206 225 255\n206 225 255\n205 225 255\n205 225 255\n205 225 255\n";
            Assert.AreEqual(BlueSkies, result.parser.Parse());
        }

        [TestMethod]
        public void RenderScene_LastRenderedDate_AutoGenerated_OK()
        {
            var newScene = new Scene
            {
                SceneName = "new scene"
            };
            _sceneLogic.Add(newScene);
            newScene.ClientScenePreferences.SetLookAtDefault((0, 2, 5));
            newScene.ClientScenePreferences.SetLookFromDefault((0, 2, 0));
            newScene.ClientScenePreferences.FoVDefault = 30;

            var updatedScene = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();
            newScene.LastRenderDate = DateTime.Now;

            Assert.AreEqual(newScene.LastRenderDate, DateTime.Now);
        }

        [TestMethod]
        public void RenderScene_LogGenerated_OK_Test()
        {
            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 1
            };
            _shapeLogic.AddShape(newShape);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(230, 15, 160);
            _materialLogic.Add(newMaterial);

            var newModel = new Model
            {
                ModelName = "NewModel",
                Shape = _shapeLogic.GetShape(newShape.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel);

            var newScene = new Scene
            {
                SceneName = "new scene"
            };
            _sceneLogic.Add(newScene);

            newScene.ClientScenePreferences.SetLookAtDefault((0, 2, 5));
            newScene.ClientScenePreferences.SetLookFromDefault((0, 2, 0));
            newScene.ClientScenePreferences.FoVDefault = 30;

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModelContext = _modelLogic.Get(newModel.ModelName);

            _sceneLogic.AddPositionedModel(newModelContext, (0, 2, 8), updatedScene1.Id);

            var updatedScene2 = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();

            Assert.AreEqual(1, _renderLogLogic.GetAll().Count);
        }

        [TestMethod]
        public void RenderScene_RenderingTimeInSeconds_OK_Test()
        {
            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 1
            };
            _shapeLogic.AddShape(newShape);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(230, 15, 160);
            _materialLogic.Add(newMaterial);

            var newModel = new Model
            {
                ModelName = "NewModel",
                Shape = _shapeLogic.GetShape(newShape.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel);

            var newScene = new Scene
            {
                SceneName = "new scene"
            };
            _sceneLogic.Add(newScene);

            newScene.ClientScenePreferences.SetLookAtDefault((0, 2, 5));
            newScene.ClientScenePreferences.SetLookFromDefault((0, 2, 0));
            newScene.ClientScenePreferences.FoVDefault = 30;

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModelContext = _modelLogic.Get(newModel.ModelName);

            _sceneLogic.AddPositionedModel(newModelContext, (0, 2, 8), updatedScene1.Id);

            var updatedScene2 = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();
            var log = _renderLogLogic.GetAll().FirstOrDefault();
            Assert.IsTrue(log.RenderingTimeInSeconds >= 0);
        }

        [TestMethod]
        public void RenderPreview_RenderWindow_OK_Test()
        {
            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 1
            };
            _shapeLogic.AddShape(newShape);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(230, 15, 160);
            _materialLogic.Add(newMaterial);

            var newModel = new Model
            {
                ModelName = "NewModel",
                Shape = _shapeLogic.GetShape(newShape.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel);

            var newScene = new Scene
            {
                SceneName = "preview-NewModel"
            };
            _sceneLogic.Add(newScene);

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModelContext = _modelLogic.Get(newModel.ModelName);

            _sceneLogic.AddPositionedModel(newModelContext, (0, 2, 8), updatedScene1.Id);

            var updatedScene2 = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();
            var log = _renderLogLogic.GetAll().FirstOrDefault();
            Assert.AreEqual("0 seconds", log.RenderWindow);
        }

        [TestMethod]
        public void RenderScene_RenderWindow_OK_Test()
        {
            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 1
            };
            _shapeLogic.AddShape(newShape);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(2, 150, 10);
            _materialLogic.Add(newMaterial);

            var newModel = new Model
            {
                ModelName = "NewModel",
                Shape = _shapeLogic.GetShape(newShape.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel);

            var newScene = new Scene
            {
                SceneName = "NewModel"
            };
            _sceneLogic.Add(newScene);

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModelContext = _modelLogic.Get(newModel.ModelName);

            _sceneLogic.AddPositionedModel(newModelContext, (0, 2, 8), updatedScene1.Id);
            _sceneLogic.AddPositionedModel(newModelContext, (10, 10, 3), updatedScene1.Id);


            var updatedScene2 = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();
            var result2 = engine.Render();
            var log = _renderLogLogic.GetAll().Last();

            Assert.IsTrue(log.RenderWindow.Contains("seconds"));
        }

        [TestMethod]
        public void RenderScene_NumberOfModels_OK_Test()
        {
            Shape newShape1 = new Sphere
            {
                ShapeName = "NewSphere1",
                Radius = 1
            };
            Shape newShape2 = new Sphere
            {
                ShapeName = "NewSphere2",
                Radius = 10
            };

            _shapeLogic.AddShape(newShape1);
            _shapeLogic.AddShape(newShape2);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(234, 3, 90);
            _materialLogic.Add(newMaterial);

            var newModel1 = new Model
            {
                ModelName = "NewModel1",
                Shape = _shapeLogic.GetShape(newShape1.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            var newModel2 = new Model
            {
                ModelName = "NewModel2",
                Shape = _shapeLogic.GetShape(newShape2.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel1);
            _modelLogic.Add(newModel2);

            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModel1Context = _modelLogic.Get(newModel1.ModelName);
            var newModel2Context = _modelLogic.Get(newModel2.ModelName);

            _sceneLogic.AddPositionedModel(newModel1Context, (0, 2, 8), updatedScene1.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (10, 10, 3), updatedScene1.Id);


            var updatedScene2 = _sceneLogic.Update(newScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render();
            var log = _renderLogLogic.GetAll().FirstOrDefault();

            Assert.AreEqual(2, log.NumberOfModels);
        }

        [TestMethod]
        public void AverageRenderTime_OK_Test()
        {
            Shape newShape1 = new Sphere
            {
                ShapeName = "NewSphere1",
                Radius = 1
            };
            Shape newShape2 = new Sphere
            {
                ShapeName = "NewSphere2",
                Radius = 10
            };

            _shapeLogic.AddShape(newShape1);
            _shapeLogic.AddShape(newShape2);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(234, 3, 90);
            _materialLogic.Add(newMaterial);

            var newModel1 = new Model
            {
                ModelName = "NewModel1",
                Shape = _shapeLogic.GetShape(newShape1.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            var newModel2 = new Model
            {
                ModelName = "NewModel2",
                Shape = _shapeLogic.GetShape(newShape2.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel1);
            _modelLogic.Add(newModel2);

            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            var anotherScene = new Scene
            {
                SceneName = "AnotherScene"
            };
            _sceneLogic.Add(anotherScene);
            var updatedAnotherScene = _sceneLogic.Update(anotherScene);

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModel1Context = _modelLogic.Get(newModel1.ModelName);
            var newModel2Context = _modelLogic.Get(newModel2.ModelName);

            _sceneLogic.AddPositionedModel(newModel1Context, (0, 2, 8), updatedScene1.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (10, 10, 3), updatedScene1.Id);

            _sceneLogic.AddPositionedModel(newModel1Context, (9, 15, 1), updatedAnotherScene.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (0, 5, 2), updatedAnotherScene.Id);


            var updatedScene2 = _sceneLogic.Update(newScene);
            var updatedAnotherScene2 = _sceneLogic.Update(anotherScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 75
            };

            var engine2 = new GraphicsEngine.GraphicsEngine(updatedAnotherScene2)
            {
                Width = 75
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result1 = engine.Render();
            var result2 = engine.Render();
            var result3 = engine2.Render();

            Assert.IsTrue(_renderLogLogic.GetAverageRenderTime() > 1);
        }

        [TestMethod]
        public void TotalRenderTimeInMinutes_OK_Test()
        {
            Shape newShape1 = new Sphere
            {
                ShapeName = "NewSphere1",
                Radius = 1
            };
            Shape newShape2 = new Sphere
            {
                ShapeName = "NewSphere2",
                Radius = 10
            };

            _shapeLogic.AddShape(newShape1);
            _shapeLogic.AddShape(newShape2);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(234, 3, 90);
            _materialLogic.Add(newMaterial);

            var newModel1 = new Model
            {
                ModelName = "NewModel1",
                Shape = _shapeLogic.GetShape(newShape1.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            var newModel2 = new Model
            {
                ModelName = "NewModel2",
                Shape = _shapeLogic.GetShape(newShape2.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel1);
            _modelLogic.Add(newModel2);

            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            var anotherScene = new Scene
            {
                SceneName = "AnotherScene"
            };
            _sceneLogic.Add(anotherScene);
            var updatedAnotherScene = _sceneLogic.Update(anotherScene);

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModel1Context = _modelLogic.Get(newModel1.ModelName);
            var newModel2Context = _modelLogic.Get(newModel2.ModelName);

            _sceneLogic.AddPositionedModel(newModel1Context, (0, 2, 8), updatedScene1.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (10, 10, 3), updatedScene1.Id);

            _sceneLogic.AddPositionedModel(newModel1Context, (9, 15, 1), updatedAnotherScene.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (0, 5, 2), updatedAnotherScene.Id);


            var updatedScene2 = _sceneLogic.Update(newScene);
            var updatedAnotherScene2 = _sceneLogic.Update(anotherScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 75
            };

            var engine2 = new GraphicsEngine.GraphicsEngine(updatedAnotherScene2)
            {
                Width = 75
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result1 = engine.Render();
            var result2 = engine.Render();
            var result3 = engine2.Render();

            Assert.IsTrue(_renderLogLogic.GetTotalRenderTimeInMinutes() >= 0);
        }


        [TestMethod]
        public void ClientWithMaxRenderTime_OK_Test()
        {
            Shape newShape1 = new Sphere
            {
                ShapeName = "NewSphere1",
                Radius = 1
            };
            Shape newShape2 = new Sphere
            {
                ShapeName = "NewSphere2",
                Radius = 10
            };

            _shapeLogic.AddShape(newShape1);
            _shapeLogic.AddShape(newShape2);

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial"
            };
            newMaterial.SetColor(234, 3, 90);
            _materialLogic.Add(newMaterial);

            var newModel1 = new Model
            {
                ModelName = "NewModel1",
                Shape = _shapeLogic.GetShape(newShape1.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            var newModel2 = new Model
            {
                ModelName = "NewModel2",
                Shape = _shapeLogic.GetShape(newShape2.ShapeName),
                Material = _materialLogic.Get(newMaterial.MaterialName)
            };
            _modelLogic.Add(newModel1);
            _modelLogic.Add(newModel2);

            var newScene = new Scene
            {
                SceneName = "NewScene"
            };
            _sceneLogic.Add(newScene);

            var anotherScene = new Scene
            {
                SceneName = "AnotherScene"
            };
            _sceneLogic.Add(anotherScene);
            var updatedAnotherScene = _sceneLogic.Update(anotherScene);

            var updatedScene1 = _sceneLogic.Update(newScene);

            var newModel1Context = _modelLogic.Get(newModel1.ModelName);
            var newModel2Context = _modelLogic.Get(newModel2.ModelName);

            _sceneLogic.AddPositionedModel(newModel1Context, (0, 2, 8), updatedScene1.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (10, 10, 3), updatedScene1.Id);

            _sceneLogic.AddPositionedModel(newModel1Context, (9, 15, 1), updatedAnotherScene.Id);
            _sceneLogic.AddPositionedModel(newModel2Context, (0, 5, 2), updatedAnotherScene.Id);


            var updatedScene2 = _sceneLogic.Update(newScene);
            var updatedAnotherScene2 = _sceneLogic.Update(anotherScene);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene2)
            {
                Width = 15
            };

            var engine2 = new GraphicsEngine.GraphicsEngine(updatedAnotherScene2)
            {
                Width = 15
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result1 = engine.Render();
            var result2 = engine.Render();
            var result3 = engine2.Render();

            Assert.AreEqual("NewClient3", _renderLogLogic.GetClientWithMaxRenderTime().Client.Name);
            Assert.IsTrue(_renderLogLogic.GetClientWithMaxRenderTime().AccumulatedRenderTime >= 0);
        }
    }
}