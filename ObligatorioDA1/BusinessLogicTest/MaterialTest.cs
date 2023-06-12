using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInDB;

namespace BusinessLogicTest
{
    [TestClass]
    public class MaterialTest
    {
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private Client client;

        [TestInitialize]
        public void CreateAndInitializeClient()
        {
            client = new Client
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
            ClearDatabase.ClearAll();
        }

        [TestMethod]
        public void Material_ValidMaterial_OK_Test()
        {
            var material = new Material
            {
                MaterialName = "VantaBlack",
            };
            material.SetColor(0, 0, 0);
            Assert.AreEqual("VantaBlack", material.MaterialName);
        }

        [TestMethod]
        public void Material_EmptyName_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var material = new Material
                {
                    MaterialName = "",
                };
            });
        }

        [TestMethod]
        public void Material_NameTrailingSpaces_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                var material = new Material
                {
                    MaterialName = "Light Gray ",
                };
            });
        }

        [TestMethod]
        public void Material_RedAbove255_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var material = new Material
                {
                    MaterialName = "Vibranium Violet",
                };
                material.SetColor(256, 80, 130);
            });
        }

        [TestMethod]
        public void Material_GreenAbove255_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var material = new Material
                {
                    MaterialName = "Geologic Green",
                };
                material.SetColor(80, 300, 130);
            });
        }


        [TestMethod]
        public void Material_BlueAbove255_Fail_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var material = new Material
                {
                    MaterialName = "Beautiful Blue",
                };
                material.SetColor(20, 0, 256);
            });
        }

        [TestMethod]
        public void AddMaterial_ValidMaterial_OK_Test()
        {
            var material = new Material
            {
                MaterialName = "Organic Orange",
            };
            material.SetColor(180, 60, 60);
            _materialLogic.Add(material);
            Assert.AreEqual(1, _materialLogic.GetAll().Count);
        }

        [TestMethod]
        public void AddMaterial_RepeatedMaterials_FAIL_Test()
        {
            var m1 = new Material
            {
                MaterialName = "Double Dummy",
            };
            m1.SetColor(110, 221, 123);
            var m2 = new Material
            {
                MaterialName = "double dummY",
            };
            m2.SetColor(30, 60, 90);
            _materialLogic.Add(m1);
            Assert.ThrowsException<NameException>(() => { _materialLogic.Add(m2); });
        }

        [TestMethod]
        public void RemoveMaterial_ValidMaterial_OK_Test()
        {
            var material = new Material
            {
                MaterialName = "Tan Tangerine",
            };
            material.SetColor(180, 60, 60);
            _materialLogic.Add(material);
            _materialLogic.Remove(material);
            Assert.AreEqual(0, _materialLogic.GetAll().Count);
        }

        [TestMethod]
        public void RemoveMaterial_NonExistantMaterial_FAIL_Test()
        {
            var material = new Material
            {
                MaterialName = "Nonexistant Neon",
            };
            material.SetColor(245, 60, 60);
            Assert.ThrowsException<NotFoundException>(() => _materialLogic.Remove(material));
        }

        [TestMethod]
        public void RenameMaterial_ValidMaterial_OK_Test()
        {
            var material = new Material
            {
                MaterialName = "Valid Vlue",
            };
            material.SetColor(180, 20, 170);
            _materialLogic.Add(material);
            _materialLogic.Rename(material, "Balid Blue");
            Assert.AreEqual("Balid Blue", material.MaterialName);
        }

        [TestMethod]
        public void RenameMaterial_InvalidMaterial_FAIL_Test()
        {
            var material = new Material
            {
                MaterialName = "Valid Vlue",
            };
            material.SetColor(180, 20, 170);
            Assert.ThrowsException<NotFoundException>(() => { _materialLogic.Rename(material, "Balid Blue"); });
        }

        [TestMethod]
        public void RenameMaterial_NameInUse_FAIL_Test()
        {
            var presentMaterial = new Material
            {
                MaterialName = "Present Purple",
            };
            presentMaterial.SetColor(180, 20, 170);
            var newMaterial = new Material
            {
                MaterialName = "Unique Unicorn",
            };
            newMaterial.SetColor(10, 45, 11);
            _materialLogic.Add(presentMaterial);
            _materialLogic.Add(newMaterial);
            Assert.ThrowsException<NameException>(() => { _materialLogic.Rename(newMaterial, "Present Purple"); });
        }

        [TestMethod]
        public void AddMaterial_Valid_Owner_Test_OK()
        {
            var newMaterial = new Material
            {
                MaterialName = "Unicorn",
            };
            newMaterial.SetColor(10, 45, 11);
            _materialLogic.Add(newMaterial);

            Assert.AreEqual(client.Name, newMaterial.Client.Name);
        }

        [TestMethod]
        public void AddMaterial_NotLogged_Test_FAIL()
        {
            _clientLogic.Logout();
            var newMaterial = new Material
            {
                MaterialName = "Unicorn",
            };
            newMaterial.SetColor(10, 50, 11);

            Assert.ThrowsException<SessionException>(() => _materialLogic.Add(newMaterial));
        }

        [TestMethod]
        public void AddMaterial_SameName_DifferentOwner_Test_OK()
        {
            var material1 = new Material
            {
                MaterialName = "Same MaterialName",
            };
            material1.SetColor(10, 50, 11);
            _materialLogic.Add(material1);
            _clientLogic.Logout();

            var anotherClient = new Client
            {
                Name = "Andrew",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(anotherClient);
            _clientLogic.InitializeSession(anotherClient);

            var material2 = new Material
            {
                MaterialName = "Same MaterialName"
            };
            material2.SetColor(10, 50, 11);
            _materialLogic.Add(material2);


            Assert.AreEqual(2, _materialLogic.GetAll().Count);
        }

        [TestMethod]
        public void GetClientMaterials_OK_Test()
        {
            var material1 = new Material
            {
                MaterialName = "Material 1"
            };
            material1.SetColor(10, 50, 11);
            var material2 = new Material
            {
                MaterialName = "Material 2",
            };
            material2.SetColor(107, 50, 15);
            _materialLogic.Add(material1);
            _materialLogic.Add(material2);
            _clientLogic.Logout();

            var anotherClient = new Client
            {
                Name = "anotherClient",
                Password = "ValidPassword123"
            };
            _clientLogic.AddClient(anotherClient);
            _clientLogic.InitializeSession(anotherClient);
            var material3 = new Material
            {
                MaterialName = "Material 3",
            };
            material3.SetColor(1, 29, 114);
            _materialLogic.Add(material3);
            Assert.AreEqual(1, _materialLogic.GetClientMaterials().Count);
        }

        [TestMethod]
        public void RemoveMaterial_AssociatedToModel_FAIL_Test()
        {
            var material = new Material
            {
                MaterialName = "VantaBlack",
            };
            material.SetColor(0, 0, 0);
            _materialLogic.Add(material);

            Shape sphere = new Sphere
            {
                ShapeName = "Sphere",
                Radius = 3
            };
            _shapeLogic.AddShape(sphere);

            var model = new Model
            {
                ModelName = "New Model",
                Shape = _shapeLogic.GetShape("Sphere"),
                Material = _materialLogic.Get("VantaBlack")
            };
            _modelLogic.Add(model);

            Assert.ThrowsException<AssociationException>(() => _materialLogic.Remove(material));
        }

        [TestMethod]
        public void AddMetallicMaterial_OK()
        {
            var material = new MetallicMaterial()
            {
                MaterialName = "Metalingus",
                Blur = 1
            };
            material.SetColor(210, 42, 11);
            _materialLogic.Add(material);
            var foundMaterial = (MetallicMaterial)_materialLogic.Get(material.MaterialName);
            Assert.AreEqual(1, foundMaterial.Blur);
        }
    }
}