using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private readonly IRepositoryClient _repositoryClient = new ClientRepositoryInDB();

        public Scene Add(Scene scene)
        {
            EnsureSceneNameUniqueness(scene.SceneName);
            AssignSceneToClient(scene);
            SetSceneDefaultValues(scene);
            _repository.Add(scene);
            return scene;
        }

        public Scene GetScene(int id)
        {
            return _repository.Get(id);
        }

        public Scene UpdateLastRender(Scene scene)
        {
            EnsureSceneExists(scene.SceneName);
            return _repository.Update(scene);
        }

        public PositionedModel AddPositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates, int id)
        {
            Scene scene = GetScene(id);
            var newPositionedModel = new PositionedModel()
            {
                Model = model,
                CoordinateX = coordinates.Item1,
                CoordinateY = coordinates.Item2,
                CoordinateZ = coordinates.Item3,
            };
            AddPositionedModel(scene, newPositionedModel);
            return newPositionedModel;
        }

        public void DeletePositionedModel(int idModel, int idScene)
        {
            Scene scene = GetScene(idScene);
            //var positionedModel = GetPositionedModel(scene, idModel);
            //scene.LastModificationDate = DateTime.Now;
            _repository.DeleteModel(scene, idModel);
        }

        public PositionedModel GetPositionedModel(Scene scene, int idModel)
        {
            return _repository.GetModel(scene, idModel);
        }

        private void AddPositionedModel(Scene scene, PositionedModel model)
        {
            scene.LastModificationDate = DateTime.Now;
            _repository.AddModel(scene, model);
        }

        private void SetSceneDefaultValues(Scene scene)
        {
            var client = _repositoryClient.Get(Session.LoggedClient.Name);
            scene.ClientScenePreferences.SetLookAtDefault(client.ClientScenePreferences.GetLookAtDefault());
            scene.ClientScenePreferences.SetLookFromDefault(client.ClientScenePreferences.GetLookFromDefault());
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
            scene.Client = Session.LoggedClient;
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
            return _repository.Update(scene);
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