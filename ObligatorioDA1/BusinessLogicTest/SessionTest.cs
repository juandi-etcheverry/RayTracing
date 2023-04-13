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
        [TestMethod]
        public void Initialize_Session_Test_OK()
        {
            ClientLogic clientLogic = new ClientLogic();
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
            ClientLogic clientLogic = new ClientLogic();
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
            ClientLogic clientLogic = new ClientLogic();
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
    }
}
