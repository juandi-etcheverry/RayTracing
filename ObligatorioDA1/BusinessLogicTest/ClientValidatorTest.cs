using BusinessLogic;
using DataHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BusinessLogicExceptions;

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
            Client newClient = new Client()
            {
                Name = "Nicolas",
                Password = "passworD123"
            };
            DataHandler.AddClient(newClient);
            Assert.AreEqual(1, DataHandler.Clients.Count);
        }

        [TestMethod]
        public void SignUp_Client_Name_NotUnique_FAIL_Test()
        {
            Client client1 = new Client()
            {
                Name = "Nicolas",
                Password = "passworD123"
            };
            DataHandler.AddClient(client1);
            Client client2 = new Client()
            {
                Name = "Nicolas",
                Password = "noimportA123"
            };
            Assert.ThrowsException<UniqueNameException>(() => DataHandler.AddClient(client2));
        }

        [TestMethod]
        public void SignUp_Client_Name_NotAlphanumeric_FAIL_Test()
        {
            Assert.ThrowsException<AlphanumericNameException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Mateo!",
                    Password = "passworD123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Name_HasSpace_FAIL_Test()
        {
            Assert.ThrowsException<NoSpacesException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Nicolas ",
                    Password = "passWord123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Name_TooShort_FAIL_Test()
        {
            Assert.ThrowsException<NotInRangeException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Ni",
                    Password = "passWord123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Name_TooLong_FAIL_Test()
        {
            Assert.ThrowsException<NotInRangeException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Ninkgrjkrgnegglknregklre",
                    Password = "Pgnjergrjk43533"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_TooShort_FAIL_Test()
        {
            Assert.ThrowsException<NotInRangeException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Mateo",
                    Password = "P"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_TooLong_FAIL_Test()
        {
            Assert.ThrowsException<NotInRangeException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Mateo",
                    Password = "Pgnjergrjk43533ojoirgoirgigreeriunuinmkki"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_NoCapitalLetter_FAIL_Test()
        {
            Assert.ThrowsException<NoCapitalLetterException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Mateo",
                    Password = "nocapitalletter123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_NoNumber_FAIL_Test()
        {
            Assert.ThrowsException<NoNumberException>(() =>
            {
                Client client = new Client()
                {
                    Name = "Mateo",
                    Password = "NoNumberPassword"
                };
            });
        }
    }
}
