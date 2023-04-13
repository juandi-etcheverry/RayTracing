using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class SessionTest
    {

        private readonly ClientLogic clientLogic = new ClientLogic();

        [TestCleanup]
        public void RemoveAllClientsAndSession()
        {
            if(clientLogic.GetLoggedClient() != null) clientLogic.Logout();
            clientLogic.GetClients().Clear();
        }

        [TestMethod]
        public void Initialize_Session_Test_OK()
        {
            Client client = new Client()
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };
            clientLogic.AddClient(client);

            clientLogic.InitializeSession(client);

            Assert.AreEqual(client, clientLogic.GetLoggedClient());
        }

        [TestMethod]
        public void Initialize_Session_Client_Not_Exist_Test_FAIL()
        {
            Client client = new Client()
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };

            Assert.ThrowsException<NotFoundException>(() => clientLogic.InitializeSession(client));
        }

        [TestMethod]
        public void Initialize_Session_Already_Initialized_Test_FAIL()
        {
            Client client1 = new Client()
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };
            clientLogic.AddClient(client1);
            Client client2 = new Client()
            {
                Name = "Juan",
                Password = "AlsoValidPassword123"
            };
            clientLogic.AddClient(client2);

            clientLogic.InitializeSession(client1);

            Assert.ThrowsException<SessionAlreadyInitializedException>(() => clientLogic.InitializeSession(client2));
        }

        [TestMethod]
        public void Logout_Test_OK()
        {
            Client client = new Client()
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };
            clientLogic.AddClient(client);
            clientLogic.InitializeSession(client);
            clientLogic.Logout();
            Assert.IsNull(clientLogic.GetLoggedClient());
        }
    }
}
