using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class MaterialTest
    {
        private MaterialLogic _materialLogic = new MaterialLogic();
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
            Assert.ThrowsException<Exception>(() =>
            {
                _materialLogic.Add(m2);
            });
        }
    }
}