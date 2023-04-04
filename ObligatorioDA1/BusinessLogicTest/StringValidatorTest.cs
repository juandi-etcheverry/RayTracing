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

        [TestMethod]
        public void HasSpaces_Letter_Space_True_OK_Test()
        {
            bool hasSpaces = StringValidator.HasSpaces("T ");
            Assert.IsTrue(hasSpaces);
        }
        
        [TestMethod]
        public void HasTrailingSpaces_EmptyString_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SpaceLetter_True_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces(" T");
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SingleLetter_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("T");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithSpaces_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("Test Word");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_LetterSpace_True_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("T ");
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void IsEmpty_EmptyString_True_OK_Test()
        {
            bool isEmpty = StringValidator.IsEmpty("");
            Assert.IsTrue(isEmpty);
        }
    }
}
