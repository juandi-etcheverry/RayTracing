using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain;

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
