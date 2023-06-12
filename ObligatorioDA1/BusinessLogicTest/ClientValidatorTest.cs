using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInDB;

namespace BusinessLogicTest
{
    [TestClass]
    public class ClientValidatorTest
    {
        private readonly ClientLogic clientLogic = new ClientLogic();

        [TestCleanup]
        public void RemoveAllClients()
        {
            ClearDatabase.ClearAll();
        }

        [TestMethod]
        public void SignUp_Client_Name_OK_Password_OK_Test()
        {
            var newClient = new Client
            {
                Name = "Nicolas",
                Password = "passworD123"
            };
            clientLogic.AddClient(newClient);
            Assert.AreEqual(1, clientLogic.GetClients().Count);
        }

        [TestMethod]
        public void SignUp_Client_Name_NotUnique_FAIL_Test()
        {
            var client1 = new Client
            {
                Name = "Nicolas",
                Password = "passworD123"
            };
            clientLogic.AddClient(client1);
            var client2 = new Client
            {
                Name = "Nicolas",
                Password = "noimportA123"
            };
            Assert.ThrowsException<NameException>(() => clientLogic.AddClient(client2));
        }

        [TestMethod]
        public void SignUp_Client_Name_NotAlphanumeric_FAIL_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var client = new Client
                {
                    Name = "Mateo!",
                    Password = "passworD123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Name_HasSpace_FAIL_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var client = new Client
                {
                    Name = "Nicolas ",
                    Password = "passWord123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Name_TooShort_FAIL_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var client = new Client
                {
                    Name = "Ni",
                    Password = "passWord123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Name_TooLong_FAIL_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var client = new Client
                {
                    Name = "Ninkgrjkrgnegglknregklre",
                    Password = "Pgnjergrjk43533"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_TooShort_FAIL_Test()
        {
            Assert.ThrowsException<PasswordException>(() =>
            {
                var client = new Client
                {
                    Name = "Mateo",
                    Password = "P"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_TooLong_FAIL_Test()
        {
            Assert.ThrowsException<PasswordException>(() =>
            {
                var client = new Client
                {
                    Name = "Mateo",
                    Password = "Pgnjergrjk43533ojoirgoirgigreeriunuinmkki"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_NoCapitalLetter_FAIL_Test()
        {
            Assert.ThrowsException<PasswordException>(() =>
            {
                var client = new Client
                {
                    Name = "Mateo",
                    Password = "nocapitalletter123"
                };
            });
        }

        [TestMethod]
        public void SignUp_Client_Password_NoNumber_FAIL_Test()
        {
            Assert.ThrowsException<PasswordException>(() =>
            {
                var client = new Client
                {
                    Name = "Mateo",
                    Password = "NoNumberPassword"
                };
            });
        }
    }
}