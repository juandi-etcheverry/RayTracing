using Domain;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
                return context.Clients.Include(c => c.ClientScenePreferences).FirstOrDefault(c => c.Name == name);
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
                Client clientToRemove = context.Clients.FirstOrDefault(c => c.Name == client.Name);
                context.Clients.Remove(clientToRemove);
                context.SaveChanges();
                return clientToRemove;
            }
        }

        public Client Update(Client client)
        {
            using (var context = new BusinessContext())
            {
                Client clientToChangeName = context.Clients.FirstOrDefault(c => c.Name == client.Name);
                clientToChangeName.Name = client.Name;
                clientToChangeName.ClientScenePreferences = client.ClientScenePreferences;
                context.SaveChanges();
                return clientToChangeName;
            }
        }
    }
}
