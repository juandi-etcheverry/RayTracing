using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    }
}