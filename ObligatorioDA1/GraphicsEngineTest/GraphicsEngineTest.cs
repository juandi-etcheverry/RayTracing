using System;
using Domain;
using GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphicsEngineTest
{
    [TestClass]
    public class GraphicsEngineTest
    {
        [TestCleanup]
        public void ResetRandom()
        {
            RandomGenerator.ShowDefaultValue = false;
        }

        [TestMethod]
        public void Render_EarthWithBall_OK()
        {
            Shape newShape = new Sphere
            {
                ShapeName = "NewSphere",
                Radius = 1
            };

            var newMaterial = new Material
            {
                MaterialName = "NewMaterial",
                Color = (230, 15, 160),
                Type = MaterialType.Lambertian
            };

            var newModel = new Model
            {
                Name = "NewModel",
                Shape = newShape,
                Material = newMaterial
            };

            var newScene = new Scene
            {
                SceneName = "new scene"
            };

            newScene.ClientScenePreferences.LookAtDefault = (0, 2, 5);
            newScene.ClientScenePreferences.LookFromDefault = (0, 2, 0);
            newScene.ClientScenePreferences.FoVDefault = 30;

            newScene.AddPositionedModel(newModel, (0, 2, 8));

            var grass = new Material
            {
                MaterialName = "Grass",
                OwnerName = "Juandi",
                Color = (14, 255, 0)
            };
            var globe = new Sphere
            {
                ShapeName = "Earth",
                OwnerName = "Juandi",
                Radius = 2000
            };
            var globeModel = new Model
            {
                Material = grass,
                Shape = globe,
                Name = "Globe",
                OwnerName = "Juandi",
                WantPreview = false
            };
            newScene.AddPositionedModel(globeModel, (0, -1999, 8));

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;
            var engine = new GraphicsEngine.GraphicsEngine
            {
                Width = 12
            };
            var result = engine.Render(newScene);
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
            newScene.ClientScenePreferences.LookAtDefault = (0, 2, 5);
            newScene.ClientScenePreferences.LookFromDefault = (0, 2, 0);
            newScene.ClientScenePreferences.FoVDefault = 30;

            var engine = new GraphicsEngine.GraphicsEngine
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render(newScene);
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
            newScene.ClientScenePreferences.LookAtDefault = (0, 2, 5);
            newScene.ClientScenePreferences.LookFromDefault = (0, 2, 0);
            newScene.ClientScenePreferences.FoVDefault = 30;

            var engine = new GraphicsEngine.GraphicsEngine
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            var result = engine.Render(newScene);
            newScene.LastRenderDate = DateTime.Now;

            Assert.AreEqual(newScene.LastRenderDate, DateTime.Now);
        }
    }
}