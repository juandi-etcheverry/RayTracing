using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogicExceptions;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class MaterialTest
    {
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
    }
}