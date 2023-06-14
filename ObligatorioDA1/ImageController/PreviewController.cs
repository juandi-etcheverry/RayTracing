using System;
using System.Drawing;
using System.IO;
using BusinessLogic;
using Domain;
using GraphicsEngine;

namespace ImageController
{
    public static class PreviewController
    {
        public static void LoadPreview(Model model)
        {
            var fileName = $"{model.Id}.ppm";
            var renderedImage = ImageParser.ConvertPpmToBitmap(fileName);
            model.Preview = renderedImage;
        }

        public static void LoadPreview(Scene scene)
        {
            var sceneDateTime = ImageParser.HashDate(scene.LastRenderDate);
            var sceneFileName = $"{scene.Client.Name}_{sceneDateTime}.ppm";
            var renderedImage = RecoverSceneImage(sceneFileName);
            scene.Preview = renderedImage;
        }

        public static void Render(Model model)
        {
            var _clientLogic = new ClientLogic();
            var _sceneLogic = new SceneLogic();
            var loggedInClient = _clientLogic.GetLoggedClient();
            var previewScene = new Scene
            {
                LastRenderDate = DateTime.Now,
                SceneName = "Preview - " + model.ModelName
            };
            previewScene.ClientScenePreferences = loggedInClient.ClientScenePreferences;
            var addedScene = _sceneLogic.Add(previewScene);

            var distanceFromCamera = Convert.ToDecimal(10.0 + Math.Pow(((Sphere)model.Shape).Radius, 1.4));

            _sceneLogic.AddPositionedModel(model, (0, 2, distanceFromCamera), addedScene.Id);
            var updatedScene = _sceneLogic.GetScene(addedScene.Id);
            updatedScene.LastRenderDate = DateTime.Now;
            var modelFileName = $"{model.Id}.ppm";
            var engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 30
            };
            var renderedPreview = engine.Render();
            renderedPreview.SaveFile(modelFileName);
            var preview = ImageParser.ConvertPpmToBitmap(modelFileName);
            model.Preview = preview;
            _sceneLogic.RemoveScene(updatedScene);
        }

        public static void Render(Scene _scene)
        {
            var engine = new GraphicsEngine.GraphicsEngine(_scene)
            {
                Width = 300
            };
            Render(_scene, engine);
        }

        public static void Render(Scene _scene, decimal blur)
        {
            var engine = new GraphicsEngine.GraphicsEngine(_scene)
            {
                Width = 300
            };
            engine.BlurCamera(blur);

            Render(_scene, engine);
        }

        private static void Render(Scene _scene, GraphicsEngine.GraphicsEngine engine)
        {
            var _sceneLogic = new SceneLogic();
            var renderedImage = engine.Render();
            _scene.LastRenderDate = DateTime.Now;
            var sceneDateTime = ImageParser.HashDate(_scene.LastRenderDate);
            var sceneFileName = $"{_scene.Client.Name}_{sceneDateTime}.ppm";
            renderedImage.SaveFile(sceneFileName);
            _sceneLogic.UpdateLastRender(_scene);
            LoadPreview(_scene);
        }

        private static Bitmap RecoverSceneImage(string filename)
        {
            try
            {
                var renderedImage = ImageParser.ConvertPpmToBitmap(filename);
                return renderedImage;
            }
            catch (FileNotFoundException noFle)
            {
                return null;
            }
        }
    }
}