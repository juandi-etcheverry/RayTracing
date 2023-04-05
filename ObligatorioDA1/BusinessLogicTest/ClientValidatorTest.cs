using BusinessLogic;
using DataHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogicTest
{
    [TestClass]
    public class ClientValidatorTest
    {
        [TestCleanup]
        public void DataHandler_RemoveAllShapes()
        {
            DataHandler.RemoveAllClients();
        }

        [TestMethod]
        public void SignUp_Client_Name_OK_Password_OK_Test()
        {
            Client newClient = new Client();
            newClient.Name = "Nicolas";
            newClient.Password = "password123";
            DataHandler.AddClient(newClient);
            Assert.AreEqual(1, DataHandler.Clients.Count);
        }
    }
}
