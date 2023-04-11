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
            return _repository.GetAll();
        }

        public Client GetClient(string name)
        {
            return _repository.Get(name);
        }

        public Client RemoveClient(Client c)
        {
            _repository.Remove(c);
            return c;
        }

        public Client AddClient(Client c)
        {
            EnsureClientNameUniqueness(c.Name);
            return _repository.Add(c);
        }

        public Client RenameClient(Client c, string newName)
        {
            EnsureClientNameUniqueness(newName);
            c.Name = newName;
            return c;
        }

        private void EnsureClientNameUniqueness(string name)
        {
            bool nameAlreadyExist = _repository.GetAll().Any(currentClient => name == currentClient.Name);
            if (nameAlreadyExist) Client.ThrowNameExists();
        }
    }
}
