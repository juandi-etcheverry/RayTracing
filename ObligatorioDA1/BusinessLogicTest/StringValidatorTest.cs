using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
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
        public void HasSpaces_WordWithSpaces_True_OK_Test()
        {
            bool hasSpaces = StringValidator.HasSpaces("Word With Spaces");
            Assert.IsTrue(hasSpaces);
        }

        public void HasSpaces_WordWithTrailingSpaces_True_OK_Test()
        {
            bool hasSpaces = StringValidator.HasSpaces("  WordWithTrailingSpaces    ");
            Assert.IsTrue(hasSpaces);
        }
        
        [TestMethod]
        public void HasTrailingSpaces_EmptyString_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SingleLetter_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("T");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SpaceLetter_True_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces(" T");
            Assert.IsTrue(hasTrailingSpaces);
        }
        
        [TestMethod]
        public void HasTrailingSpaces_LetterSpace_True_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("T ");
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithSpaces_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("Test Word");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_UnevenTrailingSpaces_True_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("  WordWithTrailingSpaces     ");
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithMultipleSpaces_False_OK_Test()
        {
            bool hasTrailingSpaces = StringValidator.HasTrailingSpaces("_   String with multiple    spaces   ->");
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void IsEmpty_EmptyString_True_OK_Test()
        {
            bool isEmpty = StringValidator.IsEmpty("");
            Assert.IsTrue(isEmpty);
        }
        
        [TestMethod]
        public void IsEmpty_Letter_False_OK_Test()
        {
            bool isEmpty = StringValidator.IsEmpty("T");
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void IsBetween_EmptyString_0And5_True_OK_Test()
        {
            bool isBetween = StringValidator.IsBetween("", 0, 5);
            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void IsBetween_Juandi_0And5_False_OK_Test()
        {
            bool isBetween = StringValidator.IsBetween("Juandi", 0, 5);
            Assert.IsFalse(isBetween);
        }
    }
}
