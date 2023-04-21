using IRepository;
using RepositoryInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLogic
{
    public class ModelLogic
    {
        private readonly IRepositoryModel _repository = new ModelRepository();

        public void Add(Model model)
        {
            AssignModelToClient(model);
            _repository.Add(model);
        }

        private void AssignModelToClient(Model model)
        {
            model.OwnerName = Session.LoggedClient.Name;
        }
    }
}
