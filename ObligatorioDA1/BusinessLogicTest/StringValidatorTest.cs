using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogicTest
{
    [TestClass]
    public class StringValidatorTest
    {
        [TestMethod]
        public void HasSpaces_EmptyString_False_OK_Test()
        {
            bool HasSpaces = StringValidator.HasSpaces("");
            Assert.IsFalse(HasSpaces);
        }
    }
}
