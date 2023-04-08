using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using DataHandlers;

namespace BusinessLogicTest
{
    [TestClass]
    public class MaterialTest
    {
        [TestMethod]
        public void Name_ValidLambertianMaterial_True_OK_Test()
        {
            Material m = new Material()
            {
                Name = "Pasto",
                Color = (25, 180, 35),
                Type = MaterialType.Lambertian
            };
            DataHandler.AddMaterial(m);
            Assert.AreEqual(1, DataHandler.Materials.Count);
        }
    }
}
