using IRepository;
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
            return _repository.Get(name);
        }

        public IList<Model> GetAll()
        {
            return _repository.GetAll();
        }

        public Model Rename(Model model, string newName)
        {
            List<Model> existingModels = _repository.FindMany(model.Name);
            bool modelExists = existingModels.Exists((existingModel) => existingModel.OwnerName == model.OwnerName);
            if (!modelExists) throw new NotFoundException("No model found");
            model.Name = newName;
            return model;
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

        private void ThrowNameInUse(string name)
        {
            throw new NameException("Model name is already in use");
        }
    }
}
