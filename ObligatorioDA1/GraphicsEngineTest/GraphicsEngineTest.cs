using System;
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

        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();


        [TestInitialize]
        public void SetUp()
        {
            Client newClient = new Client()
            {
                Name = "NewClient",
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
            if(_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
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
                MaterialName = "NewMaterial",
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

            Scene sceneContext = _sceneLogic.Update(newScene);

            Model newModelContext = _modelLogic.Get(newModel.ModelName);

            _sceneLogic.AddPositionedModel(newModelContext, (0, 2, 8), sceneContext.Id);

            var grass = new Material
            {
                MaterialName = "Grass",
            };
            grass.SetColor(14, 255, 0);
            _materialLogic.Add(grass);

            Shape globe = new Sphere()
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

            Model globeModelContext = _modelLogic.Get(globeModel.ModelName);

            _sceneLogic.AddPositionedModel(globeModelContext, (0, -1999, 8), sceneContext.Id);

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            Scene updatedScene = _sceneLogic.GetScene(sceneContext.Id);

            var engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 12,
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

            Scene updatedScene = _sceneLogic.Update(newScene);

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

            Scene updatedScene = _sceneLogic.Update(newScene);

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
    }
}