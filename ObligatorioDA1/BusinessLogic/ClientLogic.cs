using System.Collections.Generic;
using System.Linq;
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
            var c = _repository.Get(name);
            if (c == null) Client.ThrowNoClientFound();
            return c;
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
            var nameAlreadyExist = _repository.GetAll().Any(currentClient => name == currentClient.Name);
            if (nameAlreadyExist) Client.ThrowNameExists();
        }

        public void InitializeSession(Client client)
        {
            EnsureNoClientIsLoggedIn();
            EnsureClientExists(client);
            EnsurePasswordOk(client);
            Session.LoggedClient = client;
        }

        private void EnsureClientExists(Client client)
        {
            if (GetClient(client.Name) == null) Client.ThrowNoClientFound();
        }

        private void EnsureNoClientIsLoggedIn()
        {
            if (Session.LoggedClient != null) Client.ThrowClientAlreadyLoggedIn();
        }

        private void EnsurePasswordOk(Client client)
        {
            if (!IsPasswordCorrect(client)) Client.ThrowIncorrectPassword();
        }

        public Client GetLoggedClient()
        {
            return Session.LoggedClient;
        }

        public void Logout()
        {
            EnsureClientIsLoggedIn();
            Session.LoggedClient = null;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) Client.ThrowClientNotLoggedIn();
        }

        private bool IsPasswordCorrect(Client client)
        {
            return client.Password == GetClient(client.Name).Password;
        }
    }
}