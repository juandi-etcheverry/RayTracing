using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
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
            SetSceneDefaultValues(scene);
            _repository.Add(scene);
            return scene;
        }

        private void SetSceneDefaultValues(Scene scene)
        {
            var client = Session.LoggedClient;
            scene.ClientScenePreferences.LookFromDefault = client.ClientScenePreferences.LookFromDefault;
            scene.ClientScenePreferences.LookAtDefault = client.ClientScenePreferences.LookAtDefault;
            scene.ClientScenePreferences.FoVDefault = client.ClientScenePreferences.FoVDefault;
        }

        private void EnsureSceneNameUniqueness(string name)
        {
            var nameAlreadyExists = GetClientScenes().Any(currentScene => currentScene.AreNamesEqual(name));
            if (nameAlreadyExists) ThrowNameExists();
        }

        private void AssignSceneToClient(Scene scene)
        {
            EnsureClientIsLoggedIn();
            scene.OwnerName = Session.LoggedClient.Name;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        public void RemoveScene(Scene scene)
        {
            EnsureSceneExists(scene.Name);
            _repository.Remove(scene);
        }

        public Scene RenameScene(Scene scene, string newName)
        {
            EnsureSceneExists(scene.Name);
            EnsureSceneNameUniqueness(newName);
            scene.Name = newName;
            return scene;
        }

        private void EnsureSceneExists(string name)
        {
            var sceneExists = GetClientScenes().Any(scene => scene.Name.ToLower() == name.ToLower());
            if (!sceneExists) ThrowNotFound();
        }

        public Scene GetScene(string name)
        {
            var existanceValidationScene = new Scene { Name = name };
            AssignSceneToClient(existanceValidationScene);
            EnsureSceneExists(name);
            return GetSceneForOwner(existanceValidationScene);
        }

        private Scene GetSceneForOwner(Scene checkScene)
        {
            return GetClientScenes().FirstOrDefault(scene => scene.AreNamesEqual(checkScene.Name));
        }

        public IList<Scene> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Scene> GetClientScenes()
        {
            return _repository.GetAll().Where(scene => scene.OwnerName == Session.LoggedClient.Name)
                .OrderByDescending(scene => scene.LastModificationDate).ToList();
        }

        private void ThrowNotFound()
        {
            throw new NotFoundException("Scene not found");
        }
        private void ThrowNameExists()
        {
            throw new NameException("Scene name already exists");
        }
        private void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }

    }
}