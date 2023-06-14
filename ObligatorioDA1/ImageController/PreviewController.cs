using BusinessLogic;
using Domain;
using GraphicsEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImageController
{
    public static class PreviewController
    {
        public static void LoadPreview(Model model)
        {
            string fileName = $"{model.Id}.ppm";
            Bitmap renderedImage = ImageParser.ConvertPpmToBitmap(fileName);
            model.Preview = renderedImage;
        }

        public static void LoadPreview(Scene scene)
        {
            int sceneDateTime = ImageParser.HashDate(scene.LastRenderDate);
            string sceneFileName = $"{scene.Client.Name}_{sceneDateTime}.ppm";
            Bitmap renderedImage = RecoverSceneImage(sceneFileName);
            scene.Preview = renderedImage;
        }

        public static void Render(Model model)
        {
            ClientLogic _clientLogic = new ClientLogic();
            SceneLogic _sceneLogic = new SceneLogic();
            Client loggedInClient = _clientLogic.GetLoggedClient();
            Scene previewScene = new Scene()
            {
                LastRenderDate = DateTime.Now,
                SceneName = "Preview - " + model.ModelName,
            };
            previewScene.ClientScenePreferences = loggedInClient.ClientScenePreferences;
            Scene addedScene = _sceneLogic.Add(previewScene);

            decimal distanceFromCamera = Convert.ToDecimal(10.0 + Math.Pow(((Sphere)(model.Shape)).Radius, 1.4));

            _sceneLogic.AddPositionedModel(model, (0, 2, distanceFromCamera), addedScene.Id);
            Scene updatedScene = _sceneLogic.GetScene(addedScene.Id);
            updatedScene.LastRenderDate = DateTime.Now;
            string modelFileName = $"{model.Id}.ppm";
            GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 30
            };
            PPMImage renderedPreview = engine.Render();
            renderedPreview.SaveFile(modelFileName);
            Bitmap preview = ImageParser.ConvertPpmToBitmap(modelFileName);
            model.Preview = preview;
            _sceneLogic.RemoveScene(updatedScene);
        }

        public static void Render(Scene _scene)
        {
            GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine(_scene)
            {
                Width = 300
            };
            Render(_scene, engine);
        }

        public static void Render(Scene _scene, decimal blur)
        {
            GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine(_scene)
            {
                Width = 300
            };
            engine.BlurCamera(blur);
            
            Render(_scene, engine);
        }

        private static void Render(Scene _scene, GraphicsEngine.GraphicsEngine engine)
        {
            SceneLogic _sceneLogic = new SceneLogic();
            PPMImage renderedImage = engine.Render();
            _scene.LastRenderDate = DateTime.Now;
            int sceneDateTime = ImageParser.HashDate(_scene.LastRenderDate);
            string sceneFileName = $"{_scene.Client.Name}_{sceneDateTime}.ppm";
            renderedImage.SaveFile(sceneFileName);
            _sceneLogic.UpdateLastRender(_scene);
            LoadPreview(_scene);
        }

        private static Bitmap RecoverSceneImage(string filename)
        {
            try
            {
                Bitmap renderedImage = ImageParser.ConvertPpmToBitmap(filename);
                return renderedImage;
            }
            catch (FileNotFoundException noFle)
            {
                return null;
            }
        }
    }
}
