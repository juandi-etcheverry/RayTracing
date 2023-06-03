using System.Collections.Generic;
using System.Linq;
using Domain;
using IRepository;

namespace RepositoryInMemory
{
    public class ClientRepository : IRepositoryClient
    {
        private static readonly IList<Client> _clients = new List<Client>();

        public IList<Client> GetAll()
        {
            return _clients;
        }

        public Client Get(string name)
        {
            return _clients.FirstOrDefault(c => c.Name == name);
        }

        public Client Add(Client client)
        {
            _clients.Add(client);
            return client;
        }

        public Client Remove(Client client)
        {
            _clients.Remove(client);
            return client;
        }

        public Client Update(Client x, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}