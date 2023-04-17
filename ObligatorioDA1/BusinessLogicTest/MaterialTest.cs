using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using System.Net;

namespace BusinessLogicTest
{
    [TestClass]
    public class MaterialTest
    {
        private MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private Client client;

        [TestInitialize]
        public void CreateAndInitializeClient()
        {
            client = new Client()
            {
                Name = "NewClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(client);
            _clientLogic.InitializeSession(client);
        }

        [TestCleanup]
        public void RemoveAllMaterialsAndClients()
        {
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            _clientLogic.GetClients().Clear();
            _materialLogic.GetAll().Clear();
        }

        [TestMethod]
        public void Material_ValidMaterial_OK_Test()
        {
            Material material = new Material()
            {
                Name = "VantaBlack",
                Color = (0, 0, 0),
                Type = MaterialType.Lambertian
            };
            Assert.AreEqual("VantaBlack", material.Name);
        }

        [TestMethod]
        public void Material_EmptyName_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                Material material = new Material()
                {
                    Name = "",
                    Color = (0, 0, 0),
                    Type = MaterialType.Lambertian
                };
            });
        }

        [TestMethod]
        public void Material_NameTrailingSpaces_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                Material material = new Material()
                {
                    Name = "Light Gray ",
                    Color = (40, 40, 40),
                    Type = MaterialType.Lambertian
                };
            });
        }

        [TestMethod]
        public void Material_RedAbove255_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Material material = new Material()
                {
                    Name = "Vibranium Violet",
                    Color = (256, 80, 130),
                    Type = MaterialType.Lambertian
                };
            });
        }

        [TestMethod]
        public void Material_GreenAbove255_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Material material = new Material()
                {
                    Name = "Geologic Green",
                    Color = (80, 300, 130),
                    Type = MaterialType.Lambertian
                };
            });
        }


        [TestMethod]
        public void Material_BlueAbove255_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Material material = new Material()
                {
                    Name = "Beautiful Blue",
                    Color = (20, 0, 256),
                    Type = MaterialType.Lambertian
                };
            });
        }

        [TestMethod]
        public void AddMaterial_ValidMaterial_OK_Test()
        {
            Material material = new Material()
            {
                Name = "Organic Orange",
                Color = (180, 60, 60),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material);
            Assert.AreEqual(1, _materialLogic.GetAll().Count);
        }

        [TestMethod]
        public void AddMaterial_RepeatedMaterials_FAIL_Test()
        {
            Material m1 = new Material()
            {
                Name = "Double Dummy",
                Color = (110, 221, 123),
                Type = MaterialType.Lambertian
            };
            Material m2 = new Material()
            {
                Name = "double dummY",
                Color = (30, 60, 90),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(m1);
            Assert.ThrowsException<NameException>(() =>
            {
                _materialLogic.Add(m2);
            });
        }

        [TestMethod]
        public void RemoveMaterial_ValidMaterial_OK_Test()
        {
            Material material = new Material()
            {
                Name = "Tan Tangerine",
                Color = (180, 60, 60),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material);
            _materialLogic.Remove(material);
            Assert.AreEqual(0, _materialLogic.GetAll().Count);
        }

        [TestMethod]
        public void RemoveMaterial_NonExistantMaterial_FAIL_Test()
        {
            Material material = new Material()
            {
                Name = "Nonexistant Neon",
                Color = (245, 60, 60),
                Type = MaterialType.Lambertian
            };
            Assert.ThrowsException<NotFoundException>(() => _materialLogic.Remove(material));
        }

        [TestMethod]
        public void RenameMaterial_ValidMaterial_OK_Test()
        {
            Material material = new Material()
            {
                Name = "Valid Vlue",
                Color = (180, 20, 170),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material);
            _materialLogic.Rename(material, "Balid Blue");
            Assert.AreEqual(_materialLogic.Get("Balid Blue"), material);
        }

        [TestMethod]
        public void RenameMaterial_InvalidMaterial_FAIL_Test()
        {
            Material material = new Material()
            {
                Name = "Valid Vlue",
                Color = (180, 20, 170),
                Type = MaterialType.Lambertian
            };
            Assert.ThrowsException<NotFoundException>(() =>
            {
                _materialLogic.Rename(material, "Balid Blue");
            });
        }

        [TestMethod]
        public void RenameMaterial_NameInUse_FAIL_Test()
        {
            Material presentMaterial = new Material()
            {
                Name = "Present Purple",
                Color = (180, 20, 170),
                Type = MaterialType.Lambertian
            };
            Material newMaterial = new Material()
            {
                Name = "Unique Unicorn",
                Color = (10, 45, 11),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(presentMaterial);
            _materialLogic.Add(newMaterial);
            Assert.ThrowsException<NameException>(() => { _materialLogic.Rename(newMaterial, "Present Purple"); });
        }

        [TestMethod]
        public void AddMaterial_Valid_Owner_Test_OK()
        {
            Material newMaterial = new Material()
            {
                Name = "Unicorn",
                Color = (10, 45, 11),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(newMaterial);

            Assert.AreEqual(client.Name, newMaterial.OwnerName);
        }
    }
}