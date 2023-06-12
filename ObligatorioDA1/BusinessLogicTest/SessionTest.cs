using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInDB;

namespace BusinessLogicTest
{
    [TestClass]
    public class SessionTest
    {
        private readonly ClientLogic clientLogic = new ClientLogic();

        [TestCleanup]
        public void RemoveAllClientsAndSession()
        {
            if (clientLogic.GetLoggedClient() != null) clientLogic.Logout();
            ClearDatabase.ClearAll();
        }

        [TestMethod]
        public void Initialize_Session_Test_OK()
        {
            var client = new Client
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
            var client = new Client
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };

            Assert.ThrowsException<NotFoundException>(() => clientLogic.InitializeSession(client));
        }

        [TestMethod]
        public void Initialize_Session_Already_Initialized_Test_FAIL()
        {
            var client1 = new Client
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };
            clientLogic.AddClient(client1);
            var client2 = new Client
            {
                Name = "Juan",
                Password = "AlsoValidPassword123"
            };
            clientLogic.AddClient(client2);

            clientLogic.InitializeSession(client1);

            Assert.ThrowsException<SessionException>(() => clientLogic.InitializeSession(client2));
        }

        [TestMethod]
        public void Logout_Test_OK()
        {
            var client = new Client
            {
                Name = "Mateo",
                Password = "ValidPassword123"
            };
            clientLogic.AddClient(client);
            clientLogic.InitializeSession(client);
            clientLogic.Logout();
            clientLogic.RemoveClient(client);
            Assert.IsNull(clientLogic.GetLoggedClient());
        }

        [TestMethod]
        public void Logout_Not_Initialized_Test_FAIL()
        {
            Assert.ThrowsException<SessionException>(() => clientLogic.Logout());
        }
    }
}