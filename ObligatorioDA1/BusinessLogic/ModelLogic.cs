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
            model.OwnerName = Session.LoggedClient.Name;
            _repository.Add(model);
        }
    }
}
