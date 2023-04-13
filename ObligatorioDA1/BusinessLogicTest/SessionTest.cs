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
    }
}
