using Domain;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryInDB
{
    public class ClientRepositoryInDB : IRepositoryClient
    {
        public Client Add(Client client)
        {
            using (var context = new BusinessContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
            return client;
        }

        public Client Get(string name)
        {
            using (var context = new BusinessContext())
            {
                return context.Clients.FirstOrDefault(c => c.Name == name);
            }
        }

        public IList<Client> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Clients.ToList();
            }
        }

        public Client Remove(Client client)
        {
            using (var context = new BusinessContext())
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
            return client;
        }
    }
}
