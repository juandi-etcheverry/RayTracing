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
            bool hasSpaces = "".HasSpaces();
            Assert.IsFalse(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_SingleSpace_True_OK_Test()
        {
            bool hasSpaces = " ".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_SingleLetter_False_OK_Test()
        {
            bool hasSpaces = "T".HasSpaces();
            Assert.IsFalse(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_Letter_Space_True_OK_Test()
        {
            bool hasSpaces = "T ".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_WordWithSpaces_True_OK_Test()
        {
            bool hasSpaces = "Word With Spaces".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_WordWithTrailingSpaces_True_OK_Test()
        {
            bool hasSpaces = "  WordWithTrailingSpaces    ".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }
        
        [TestMethod]
        public void HasTrailingSpaces_EmptyString_False_OK_Test()
        {
            bool hasTrailingSpaces = "".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SingleLetter_False_OK_Test()
        {
            bool hasTrailingSpaces = "T".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SpaceLetter_True_OK_Test()
        {
            bool hasTrailingSpaces = " T".HasTrailingSpaces();
            Assert.IsTrue(hasTrailingSpaces);
        }
        
        [TestMethod]
        public void HasTrailingSpaces_LetterSpace_True_OK_Test()
        {
            bool hasTrailingSpaces = "T ".HasTrailingSpaces();
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithSpaces_False_OK_Test()
        {
            bool hasTrailingSpaces = "Test Word".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_UnevenTrailingSpaces_True_OK_Test()
        {
            bool hasTrailingSpaces = "  WordWithTrailingSpaces     ".HasTrailingSpaces();
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithMultipleSpaces_False_OK_Test()
        {
            bool hasTrailingSpaces = "_   String with multiple    spaces   ->".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void IsEmpty_EmptyString_True_OK_Test()
        {
            bool isEmpty = "".IsEmpty();
            Assert.IsTrue(isEmpty);
        }
        
        [TestMethod]
        public void IsEmpty_Letter_False_OK_Test()
        {
            bool isEmpty = "T".IsEmpty();
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void IsBetween_EmptyString_0And5_True_OK_Test()
        {
            bool isBetween = "".IsBetween(0, 5);
            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void IsBetween_Juandi_0And5_False_OK_Test()
        {
            bool isBetween = "Juandi".IsBetween(0, 5);
            Assert.IsFalse(isBetween);
        }

        [TestMethod]
        public void IsBetween_Mateo_0And5_True_OK_Test()
        {
            bool isBetween = "Mateo".IsBetween(0, 5);
            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void IsBetween_Nico_5And10_False_OK_Test()
        {
            bool isBetween = "Nico".IsBetween(5, 10);
            Assert.IsFalse(isBetween);
        }

        [TestMethod]
        public void IsAlphaNumeric_Juandi_True_OK_Test()
        {
            bool isAlphaNumeric = "Juandi".IsAlphaNumeric();
            Assert.IsTrue(isAlphaNumeric);
        }

        [TestMethod]
        public void IsAlphaNumeric_Scribble_False_OK_Test()
        {
            string scribble = "~./-=>";
            bool isAlphaNumeric = scribble.IsAlphaNumeric();
            Assert.IsFalse(isAlphaNumeric);
        }

        [TestMethod]
        public void IsAlphaNumeric_Juandi0402_True_OK_Test()
        {
            bool isAlphaNumeric = "Juandi0402".IsAlphaNumeric();
            Assert.IsTrue(isAlphaNumeric);
        }

        [TestMethod]
        public void IsAlphaNumeric_EmptyString_False_OK_Test()
        {
            bool isAlphaNumeric = "".IsAlphaNumeric();
            Assert.IsFalse(isAlphaNumeric);
        }

        [TestMethod]
        public void HasUpper_EmptyString_False_OK_Test()
        {
            bool hasUpper = "".HasUpper();
            Assert.IsFalse(hasUpper);
        }
        
        [TestMethod]
        public void HasUpper_UppercaseLetter_True_OK_Test()
        {
            bool hasUpper = "T".HasUpper();
            Assert.IsTrue(hasUpper);   
        }

        [TestMethod]
        public void HasUpper_LowercaseLetter_False_OK_Test()
        {
            bool hasUpper = "t".HasUpper();
            Assert.IsFalse(hasUpper);
        }

    }
}
