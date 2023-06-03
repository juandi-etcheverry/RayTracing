using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInDB;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class ModelLogic
    {
        private readonly IRepositoryModel _repository = new ModelRepositoryInDB();

        public void Add(Model model)
        {
            AssignModelToClient(model);
            ValidateMaterialNameUniqueness(model);
            _repository.Add(model);
        }

        public Model Get(string name)
        {
            var existanceValidationModel = new Model { ModelName = name };
            AssignModelToClient(existanceValidationModel);
            ValidateModelExists(existanceValidationModel);
            return GetModelForOwner(existanceValidationModel);
        }

        public IList<Model> GetClientModels()
        {
            EnsureClientIsLoggedIn();
            return _repository.GetAll().Where(model => model.Client.Name == Session.LoggedClient.Name).ToList();
        }

        public IList<Model> GetAll()
        {
            return _repository.GetAll();
        }

        public Model Rename(Model model, string newName)
        {
            ValidateRenaming(model, newName);
            return _repository.Update(model, newName);
        }

        public Model Remove(Model model)
        {
            ValidateModelExists(model);
            ValidateModelReferencedByScene(model);
            _repository.Remove(model);
            return model;
        }

        private void ValidateModelReferencedByScene(Model model)
        {
            var sceneLogic = new SceneLogic();
            var isModelInUse = sceneLogic.GetClientScenes().Any(scene =>
                scene.Models.Any(positionedModel => positionedModel.Model.ModelName == model.ModelName));

            if (isModelInUse) throw new AssociationException("Model is already being used by a Scene");
        }

        private void ValidateRenaming(Model model, string newName)
        {
            ValidateModelExists(model);
            var nameUniquenessValidationModel = new Model { ModelName = newName };
            AssignModelToClient(nameUniquenessValidationModel);
            ValidateModelNameUniqueness(nameUniquenessValidationModel);
        }

        private void ValidateModelNameUniqueness(Model model)
        {
            if (IsModelNameInUse(model)) ThrowNameInUse(model.ModelName);
        }

        private void ValidateModelExists(Model model)
        {
            if (!IsModelNameInUse(model)) ThrowNotFound(model.ModelName);
        }

        private void AssignModelToClient(Model model)
        {
            EnsureClientIsLoggedIn();
            model.Client = Session.LoggedClient;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        private void ValidateMaterialNameUniqueness(Model model)
        {
            if (IsModelNameInUse(model)) ThrowNameInUse(model.ModelName);
        }

        private bool IsModelNameInUse(Model model)
        {
            var existingModels = _repository.FindMany(model.ModelName);
            return existingModels.Exists(existingModel => existingModel.Client.Name == model.Client.Name);
        }

        private Model GetModelForOwner(Model checkModel)
        {
            return GetClientModels().FirstOrDefault(model => model.ModelName.ToLower() == checkModel.ModelName.ToLower());
        }

        private void ThrowNameInUse(string name)
        {
            throw new NameException($"Model {name} name is already in use");
        }

        private void ThrowNotFound(string name)
        {
            throw new NotFoundException($"No material with the name {name} was found");
        }
        public void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client needs to be logged in to create new model");
        }
    }
}