﻿using IRepository;
using RepositoryInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BusinessLogicExceptions;

namespace BusinessLogic
{
    public class ModelLogic
    {
        private readonly IRepositoryModel _repository = new ModelRepository();

        public void Add(Model model)
        {
            AssignModelToClient(model);
            ValidateMaterialNameUniqueness(model);
            _repository.Add(model);
        }

        public Model Get(string name)
        {
            Model existanceValidationModel = new Model() { Name = name };
            AssignModelToClient(existanceValidationModel);
            ValidateModelExists(existanceValidationModel);
            return GetModelForOwner(existanceValidationModel);
        }

        public IList<Model> GetClientModels()
        {
            EnsureClientIsLoggedIn();
            return _repository.GetAll().Where(model => model.OwnerName == Session.LoggedClient.Name).ToList();
        }

        public IList<Model> GetAll()
        {
            return _repository.GetAll();
        }

        public Model Rename(Model model, string newName)
        {
            ValidateRenaming(model, newName);
            model.Name = newName;
            return model;
        }

        public Model Remove(Model model)
        {
            ValidateModelExists(model);

            SceneLogic sceneLogic = new SceneLogic();
            bool isModelInUse = sceneLogic.GetClientScenes().
                                            Any(scene => scene.Models.
                                            Any(positionedModel => positionedModel.Name == model.Name));

            if (isModelInUse) throw new AssociationException("Model is already being used by a Scene");

            _repository.Remove(model);
            return model;
        }

        private void ValidateRenaming(Model model, string newName)
        {
            ValidateModelExists(model);
            Model nameUniquenessValidationModel = new Model() { Name = newName };
            AssignModelToClient(nameUniquenessValidationModel);
            ValidateModelNameUniqueness(nameUniquenessValidationModel);
        }

        private void ValidateModelNameUniqueness(Model model)
        {
            if(IsModelNameInUse(model)) ThrowNameInUse(model.Name);
        }

        private void ValidateModelExists(Model model)
        {
            if (!IsModelNameInUse(model)) ThrowNotFound(model.Name);
        }

        private void AssignModelToClient(Model model)
        {
            EnsureClientIsLoggedIn();
            model.OwnerName = Session.LoggedClient.Name;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) Model.ThrowClientNotLoggedIn();
        }

        private void ValidateMaterialNameUniqueness(Model model)
        {
            if(IsModelNameInUse(model)) ThrowNameInUse(model.Name);
        }

        private bool IsModelNameInUse(Model model)
        {
            List<Model> existingModels = _repository.FindMany(model.Name);
            return existingModels.Exists(existingModel => existingModel.OwnerName == model.OwnerName);
        }

        private Model GetModelForOwner(Model checkModel)
        {
            return GetClientModels().FirstOrDefault(model => model.Name.ToLower() == checkModel.Name.ToLower());
        }

        private void ThrowNameInUse(string name)
        {
            throw new NameException($"Model {name} name is already in use");
        }

        private void ThrowNotFound(string name)
        {
            throw new NotFoundException($"No material with the name {name} was found");
        }
    }
}
