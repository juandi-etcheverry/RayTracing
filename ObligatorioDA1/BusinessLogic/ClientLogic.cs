using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class ClientLogic
    {
        private readonly IRepositoryClient _repository = new ClientRepository();

        public IList<Client> GetClients()
        {
            return _repository.GetClients();
        }
        public ClientLogic(IRepositoryClient clientRepository)
        {
            _repository = clientRepository;
        }

        public Client GetClient(string name)
        {
            return _repository.GetClient(name);
        }

        public Client RemoveClient(Client c)
        {
            _repository.RemoveClient(c);
            return c;
        }

        public Client AddClient(Client c)
        {
            EnsureClientNameUniqueness(c.Name);
            return _repository.AddClient(c);
        }

        public Client RenameClient(Client c, string newName)
        {
            EnsureClientNameUniqueness(newName);
            c.Name = newName;
            return c;
        }

        private void EnsureClientNameUniqueness(string name)
        {
            bool nameAlreadyExist = _repository.GetClients().Any(currentClient => name == currentClient.Name);
            if (nameAlreadyExist) Client.ThrowNameExists();
        }
    }
}
