using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInDB;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class SceneLogic
    {
        private readonly IRepositoryScene _repository = new SceneRepositoryInDB();

        public Scene Add(Scene scene)
        {
            EnsureSceneNameUniqueness(scene.SceneName);
            AssignSceneToClient(scene);
            SetSceneDefaultValues(scene);
            _repository.Add(scene);
            return scene;
        }

        private void SetSceneDefaultValues(Scene scene)
        {
            var client = Session.LoggedClient;
            scene.ClientScenePreferences.LookFromDefaultX = client.ClientScenePreferences.LookFromDefaultX;
            scene.ClientScenePreferences.LookFromDefaultY = client.ClientScenePreferences.LookFromDefaultY;
            scene.ClientScenePreferences.LookFromDefaultZ = client.ClientScenePreferences.LookFromDefaultZ;

            scene.ClientScenePreferences.LookAtDefaultX = client.ClientScenePreferences.LookAtDefaultX;
            scene.ClientScenePreferences.LookAtDefaultY = client.ClientScenePreferences.LookAtDefaultY;
            scene.ClientScenePreferences.LookAtDefaultZ = client.ClientScenePreferences.LookAtDefaultZ;

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
            scene.Client.Name = Session.LoggedClient.Name;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        public void RemoveScene(Scene scene)
        {
            EnsureSceneExists(scene.SceneName);
            _repository.Remove(scene);
        }

        public Scene RenameScene(Scene scene, string newName)
        {
            EnsureSceneExists(scene.SceneName);
            EnsureSceneNameUniqueness(newName);
            scene.SceneName = newName;
            return scene;
        }

        private void EnsureSceneExists(string name)
        {
            var sceneExists = GetClientScenes().Any(scene => scene.SceneName.ToLower() == name.ToLower());
            if (!sceneExists) ThrowNotFound();
        }

        public Scene GetScene(string name)
        {
            var existanceValidationScene = new Scene { SceneName = name };
            AssignSceneToClient(existanceValidationScene);
            EnsureSceneExists(name);
            return GetSceneForOwner(existanceValidationScene);
        }

        private Scene GetSceneForOwner(Scene checkScene)
        {
            return GetClientScenes().FirstOrDefault(scene => scene.AreNamesEqual(checkScene.SceneName));
        }

        public IList<Scene> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Scene> GetClientScenes()
        {
            return _repository.GetAll().Where(scene => scene.Client.Name == Session.LoggedClient.Name)
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