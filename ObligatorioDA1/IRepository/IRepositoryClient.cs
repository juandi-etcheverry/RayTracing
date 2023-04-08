using Domain;
using System.Collections.Generic;

namespace IRepository
{
    public interface IRepositoryClient
    {
        IList<Client> GetClients();
        Client GetClient(string name);
        Client AddClient(Client client);
        Client RemoveClient(Client client);
    }
}
