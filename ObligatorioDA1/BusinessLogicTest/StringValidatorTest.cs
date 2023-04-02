using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;

namespace BusinessLogicTest
{
    [TestClass]
    public class StringValidatorTest
    {
        [TestMethod]
        public void HasSpaces_EmptyString_False_OK_Test()
        {
            bool hasSpaces = StringValidator.HasSpaces("");
            Assert.IsFalse(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_SingleSpace_True_OK_Test()
        {
            bool hasSpaces = StringValidator.HasSpaces(" ");
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_SingleLetter_False_OK_Test()
        {
            bool hasSpaces = StringValidator.HasSpaces("T");
            Assert.IsFalse(hasSpaces);
        }
    }
}
