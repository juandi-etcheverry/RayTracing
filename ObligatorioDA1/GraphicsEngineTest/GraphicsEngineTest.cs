using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Shape newShape = new Sphere()
            {
                Name = "NewSphere",
                Radius = 1,
            };

            Material newMaterial = new Material()
            {
                Name = "NewMaterial",
                Color = (230, 15, 160),
                Type = MaterialType.Lambertian
            };

            Model newModel = new Model()
            {
                Name = "NewModel",
                Shape = newShape,
                Material = newMaterial,
            };

            Scene newScene = new Scene()
            {
                Name = "new scene"
            };

            newScene.ClientScenePreferences.LookAtDefault = (0, 2, 5);
            newScene.ClientScenePreferences.LookFromDefault = (0, 2, 0);
            newScene.ClientScenePreferences.FoVDefault = 30;

            newScene.AddPositionedModel(newModel, (0, 2, 8));

            Material grass = new Material()
            {
                Name = "Grass",
                OwnerName = "Juandi",
                Color = (14, 255, 0)
            };
            Sphere globe = new Sphere()
            {
                Name = "Earth",
                OwnerName = "Juandi",
                Radius = 2000
            };
            Model globeModel = new Model()
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
            GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine()
            {
                Width = 12
            };
            PPMImage result = engine.Render(newScene);
            string TrueImage = "P3\n12 8\n255\n178 209 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n178 209 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n181 210 255\n181 210 255\n181 210 255\n181 210 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n130 11 160\n130 11 160\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n189 216 255\n189 216 255\n189 216 255\n189 215 255\n158 12 160\n159 12 160\n159 12 160\n158 12 160\n189 215 255\n189 216 255\n189 216 255\n189 216 255\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n6 11 0\n6 11 0\n6 11 0\n6 11 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n0 1 0\n0 1 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n7 179 0\n";
            Assert.AreEqual(TrueImage, result.parser.Parse());
        }

        [TestMethod]
        public void Render_EmptyScene_OK()
        {
            Scene newScene = new Scene()
            {
                Name = "new scene"
            };
            newScene.ClientScenePreferences.LookAtDefault = (0, 2, 5);
            newScene.ClientScenePreferences.LookFromDefault = (0, 2, 0);
            newScene.ClientScenePreferences.FoVDefault = 30;

            GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine()
            {
                Width = 12
            };

            RandomGenerator.ShowDefaultValue = true;
            RandomGenerator.DefaultValue = 0.5;

            PPMImage result = engine.Render(newScene);
            string BlueSkies = "P3\n12 8\n255\n178 209 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n177 208 255\n178 209 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n181 210 255\n181 210 255\n181 210 255\n181 210 255\n181 211 255\n181 211 255\n181 211 255\n181 211 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n185 213 255\n189 216 255\n189 216 255\n189 216 255\n189 215 255\n189 215 255\n189 215 255\n189 215 255\n189 215 255\n189 215 255\n189 216 255\n189 216 255\n189 216 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n193 218 255\n197 220 255\n197 220 255\n197 220 255\n198 221 255\n198 221 255\n198 221 255\n198 221 255\n198 221 255\n198 221 255\n197 220 255\n197 220 255\n197 220 255\n201 223 255\n201 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n202 223 255\n201 223 255\n201 223 255\n205 225 255\n205 225 255\n205 225 255\n206 225 255\n206 225 255\n206 225 255\n206 225 255\n206 225 255\n206 225 255\n205 225 255\n205 225 255\n205 225 255\n";
            Assert.AreEqual(BlueSkies, result.parser.Parse());
        }
    }
}
