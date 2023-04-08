using Domain;
using IRepository;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryInMemory
{
    public class ClientRepository : IRepositoryClient
    {
        private static readonly IList<Client> _clients = new List<Client>();

        public IList<Client> GetClients()
        {
            return _clients;
        }
        public Client GetClient(string name)
        {
            return _clients.FirstOrDefault(c => c.Name == name);
        }

        public Client AddClient(Client client)
        {
            _clients.Add(client);
            return client;
        }
        public Client RemoveClient(Client client)
        {
            _clients.Remove(client);
            return client;
        }
    }
}
