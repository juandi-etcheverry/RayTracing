using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInDB;

namespace BusinessLogic
{
    public class ClientLogic
    {
        private readonly IRepositoryClient _repository = new ClientRepositoryInDB();

        public IList<Client> GetClients()
        {
            return _repository.GetAll();
        }

        public Client GetClient(string name)
        {
            var c = _repository.Get(name);
            if (c == null) ThrowNoClientFound();
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
            if (nameAlreadyExist) ThrowNameExists();
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
            if (GetClient(client.Name) == null) ThrowNoClientFound();
        }

        private void EnsureNoClientIsLoggedIn()
        {
            if (Session.LoggedClient != null) ThrowClientAlreadyLoggedIn();
        }

        private void EnsurePasswordOk(Client client)
        {
            if (!IsPasswordCorrect(client)) ThrowIncorrectPassword();
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

        public void Update(Client client)
        {
            _repository.Update(client);
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        private bool IsPasswordCorrect(Client client)
        {
            return client.Password == GetClient(client.Name).Password;
        }

        public void ThrowIfIncorrectPassword(Client client, string password)
        {
            if (client.Password != password) ThrowIncorrectPassword();
        }

        private void ThrowNameExists()
        {
            throw new NameException("Client name already exists");
        }

        private void ThrowNoClientFound()
        {
            throw new NotFoundException("No client found");
        }

        private void ThrowClientAlreadyLoggedIn()
        {
            throw new SessionException("Client already logged in");
        }

        private void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }

        private void ThrowIncorrectPassword()
        {
            throw new SessionException("Incorrect password");
        }
    }
}