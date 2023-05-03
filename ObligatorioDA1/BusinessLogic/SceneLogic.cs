using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IRepository;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class SceneLogic
    {
        private readonly IRepositoryScene _repository = new SceneRepository();

        public Scene Add(Scene scene)
        {
            EnsureSceneNameUniqueness(scene.Name);
            AssignSceneToClient(scene);
            _repository.Add(scene);
            return scene;
        }

        private void EnsureSceneNameUniqueness(string name)
        {
            bool nameAlreadyExists = GetClientScenes().
                Any(currentScene => currentScene.AreNamesEqual(name));
            if (nameAlreadyExists) Scene.ThrowNameExists();
        }

        private void AssignSceneToClient(Scene scene)
        {
            EnsureClientIsLoggedIn();
            scene.OwnerName = Session.LoggedClient.Name;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) Scene.ThrowClientNotLoggedIn();
        }

        public void RemoveScene(Scene scene)
        {
            EnsureSceneExists(scene.Name);
            _repository.Remove(scene);
        }

        public Scene RenameScene(Scene scene, string newName)
        {
            scene.Name = newName;
            return scene;
        }

        private void EnsureSceneExists(string name)
        {
            bool sceneExists = GetClientScenes().Any(scene => scene.Name.ToLower() == name.ToLower());
            if(!sceneExists) Scene.ThrowNotFound();
        }

        public Scene GetScene(string name)
        {
            EnsureSceneExists(name);
            return _repository.Get(name);
        }

        public IList<Scene> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Scene> GetClientScenes()
        {
            return _repository.GetAll().Where(scene => scene.OwnerName == Session.LoggedClient.Name).
                                        OrderByDescending(scene => scene.LastModificationDate).ToList();
        }
    }
}
