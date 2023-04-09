using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClientLogic c = new ClientLogic();
            Client nico = new Client()
            {
                Name = "Nicolas",
                Password = "nicoGamer123"
            };
            c.AddClient(nico);
            ClientLogic c2 = new ClientLogic();
            Assert.AreEqual(nico, c2.GetClient("Nicolas"));
        }
    }
}
