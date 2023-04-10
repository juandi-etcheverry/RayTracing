using Domain;
using System.Collections.Generic;

namespace IRepository
{
    public interface IRepositoryClient: IRepository<Client>
    {
        IList<Client> GetAll();
        Client Get(string name);
        Client Add(Client client);
        Client Remove(Client client);
    }
}
