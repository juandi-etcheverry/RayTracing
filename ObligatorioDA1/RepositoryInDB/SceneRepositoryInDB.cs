using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;
using IRepository;
using System.Runtime.Remoting.Contexts;

namespace RepositoryInDB
{
    public class SceneRepositoryInDB : IRepositoryScene
    {
        public Scene Add(Scene scene)
        {
            using (var context = new BusinessContext())
            {
                Client loggedClient = context.Clients.FirstOrDefault(c => c.Name == scene.Client.Name);
                scene.Client = loggedClient;
                context.Scenes.Add(scene);
                context.SaveChanges();
            }
            return scene;
        }

        public IList<Scene> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Scenes
                            .Include(s => s.Client)
                            .Include(s => s.Models)
                            .ToList();
            }
        }

        public Scene Get(int id)
        {
            using (var context = new BusinessContext())
            {
                return GetWithContext(context, id);
            }
        }

        private Scene GetWithContext(BusinessContext context, int id)
        {
            return context.Scenes
                .Include(s => s.Client)
                .Include(s => s.Models.Select(p => p.Model))
                .Include(s => s.Models.Select(p => p.Model).Select(m => m.Material))
                .Include(s => s.Models.Select(p => p.Model).Select(m => m.Shape))
                .Include(s => s.ClientScenePreferences)
                .FirstOrDefault(s => s.Id == id);
        }

        public Scene Remove(Scene scene)
        {
            using (var context = new BusinessContext())
            {
                Scene sceneToRemove = context.Scenes.Include(s => s.Models).FirstOrDefault(s => s.Id == scene.Id);
                context.Scenes.Remove(sceneToRemove);
                context.SaveChanges();
                return sceneToRemove;
            }
        }

        public void AddModel(Scene scene, PositionedModel model)
        {
            using (var context = new BusinessContext())
            {
                Client loggedClient = context.Clients
                    .Include(c => c.ClientScenePreferences)
                    .FirstOrDefault(c => c.Name == scene.Client.Name);

                Scene sceneAux = context.Scenes
                    .Include(s => s.Models)
                    .Include(s => s.ClientScenePreferences)
                    .FirstOrDefault(s => s.Id == scene.Id);

                sceneAux.Client = loggedClient;

                Model modelAux = context.Models.Find(model.Model.Id);
                model.Model = modelAux;

                sceneAux.Models.Add(model);
                context.SaveChanges();
            }
        }

        public void DeleteModel(Scene scene, PositionedModel model)
        {
            using (var context = new BusinessContext())
            {
                Scene sceneToDelete = context.Scenes
                    .Include(m => m.Models)
                    .Include(m => m.ClientScenePreferences)
                    .FirstOrDefault(s => s.Id == scene.Id);

                PositionedModel modelAux = context.Scenes.Include(s => s.Models).FirstOrDefault(s => s.Id == scene.Id).Models
                    .FirstOrDefault(m => m.Id == model.Id);

                sceneToDelete.Models.Remove(modelAux);
                context.SaveChanges();
            }
        }

        public PositionedModel GetModel(Scene scene, string modelName)
        {
            using (var context = new BusinessContext())
            {
                Scene sceneToGet = context.Scenes
                    .Include(m => m.Models.Select(p => p.Model).Select(x => x.Shape))
                    .Include(m => m.Models.Select(p => p.Model).Select(x => x.Material))
                    .FirstOrDefault(s => s.Id == scene.Id);

                return sceneToGet.Models.FirstOrDefault(m =>
                    m.Model.ModelName == modelName);
            }
        }

        public Scene Update(Scene scene)
        {
            using (var context = new BusinessContext())
            {
                Scene sceneToUpdate = GetWithContext(context, scene.Id);
                sceneToUpdate.SceneName = scene.SceneName;
                sceneToUpdate.LastModificationDate = scene.LastModificationDate;
                sceneToUpdate.LastRenderDate = scene.LastRenderDate;
                sceneToUpdate.ClientScenePreferences = scene.ClientScenePreferences;
                context.SaveChanges();
                return sceneToUpdate;
            }
        }
    }
}
