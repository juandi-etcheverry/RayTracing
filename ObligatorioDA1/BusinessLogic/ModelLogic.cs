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
            List<Model> existingModels = _repository.FindMany(model.Name);
            bool nameIsTaken = existingModels.Exists(existingModel => existingModel.OwnerName == model.OwnerName);
            if(nameIsTaken) throw new NameException("Model name is already in use");
        }
    }
}
