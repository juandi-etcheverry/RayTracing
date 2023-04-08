using Domain;
using IRepository;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryInMemory
{
    public class ClientRepository : IRepositoryClient
    {
        private static readonly IList<Client> Clients = new List<Client>();

        public IList<Client> GetClients()
        {
            return Clients;
        }
        public Client GetClient(string name)
        {
            return Clients.FirstOrDefault(c => c.Name == name);
        }

        public Client AddClient(Client client)
        {
            Clients.Add(client);
            return client;
        }

        public Client RemoveClient(Client client)
        {
            Clients.Remove(client);
            return client;
        }
    }
}
