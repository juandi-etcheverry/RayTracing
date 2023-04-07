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

        [TestMethod]
        public void SignUp_Client_Name_NotUnique_FAIL_Test()
        {
            Client client1 = new Client();
            client1.Name = "Nicolas";
            client1.Password = "password123";
            DataHandler.AddClient(client1);
            Client client2 = new Client();
            client2.Name = "Nicolas";
            client2.Password = "noimporta123";
            Assert.ThrowsException<UniqueNameException>(() => DataHandler.AddClient(client2));
        }

        [TestMethod]
        public void SignUp_Client_Name_NotAlphanumeric_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "Mateo!",
                Password = "password123"
            };
            Assert.ThrowsException<AlphanumericNameException>(() => DataHandler.AddClient(client));
        }

        [TestMethod]
        public void SignUp_Client_Name_HasSpace_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "Nicolas ",
                Password = "password123"
            };
            Assert.ThrowsException<NoSpacesException>(() => DataHandler.AddClient(client));
        }

        [TestMethod]
        public void SignUp_Client_Name_TooShort_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "Ni",
                Password = "password123"
            };
            Assert.ThrowsException<NotInRangeException>(() => DataHandler.AddClient(client));
        }

        [TestMethod]
        public void SignUp_Client_Name_TooLong_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "Ninkgrjkrgnegglknregklre",
                Password = "Pgnjergrjk43533"
            };
            Assert.ThrowsException<NotInRangeException>(() => DataHandler.AddClient(client));
        }

        [TestMethod]
        public void SignUp_Client_Password_TooShort_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "Mateo",
                Password = "P"
            };
            Assert.ThrowsException<NotInRangeException>(() => DataHandler.AddClient(client));
        }

        [TestMethod]
        public void SignUp_Client_Password_TooLong_FAIL_Test()
        {
            Client client = new Client()
            {
                Name = "Mateo",
                Password = "Pgnjergrjk43533ojoirgoirgigreeriunuinmkki"
            };
            Assert.ThrowsException<NotInRangeException>(() => DataHandler.AddClient(client));
        }
    }
}
