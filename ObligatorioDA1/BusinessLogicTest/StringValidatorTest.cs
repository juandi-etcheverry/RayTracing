using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationService;

namespace BusinessLogicTest
{
    [TestClass]
    public class StringValidatorTest
    {
        [TestMethod]
        public void HasSpaces_EmptyString_False_OK_Test()
        {
            var hasSpaces = "".HasSpaces();
            Assert.IsFalse(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_SingleSpace_True_OK_Test()
        {
            var hasSpaces = " ".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_SingleLetter_False_OK_Test()
        {
            var hasSpaces = "T".HasSpaces();
            Assert.IsFalse(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_Letter_Space_True_OK_Test()
        {
            var hasSpaces = "T ".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_WordWithSpaces_True_OK_Test()
        {
            var hasSpaces = "Word With Spaces".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasSpaces_WordWithTrailingSpaces_True_OK_Test()
        {
            var hasSpaces = "  WordWithTrailingSpaces    ".HasSpaces();
            Assert.IsTrue(hasSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_EmptyString_False_OK_Test()
        {
            var hasTrailingSpaces = "".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SingleLetter_False_OK_Test()
        {
            var hasTrailingSpaces = "T".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_SpaceLetter_True_OK_Test()
        {
            var hasTrailingSpaces = " T".HasTrailingSpaces();
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_LetterSpace_True_OK_Test()
        {
            var hasTrailingSpaces = "T ".HasTrailingSpaces();
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithSpaces_False_OK_Test()
        {
            var hasTrailingSpaces = "Test Word".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_UnevenTrailingSpaces_True_OK_Test()
        {
            var hasTrailingSpaces = "  WordWithTrailingSpaces     ".HasTrailingSpaces();
            Assert.IsTrue(hasTrailingSpaces);
        }

        [TestMethod]
        public void HasTrailingSpaces_WordWithMultipleSpaces_False_OK_Test()
        {
            var hasTrailingSpaces = "_   String with multiple    spaces   ->".HasTrailingSpaces();
            Assert.IsFalse(hasTrailingSpaces);
        }

        [TestMethod]
        public void IsEmpty_EmptyString_True_OK_Test()
        {
            var isEmpty = "".IsEmpty();
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsEmpty_Letter_False_OK_Test()
        {
            var isEmpty = "T".IsEmpty();
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void IsBetween_EmptyString_0And5_True_OK_Test()
        {
            var isBetween = "".IsBetween(0, 5);
            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void IsBetween_Juandi_0And5_False_OK_Test()
        {
            var isBetween = "Juandi".IsBetween(0, 5);
            Assert.IsFalse(isBetween);
        }

        [TestMethod]
        public void IsBetween_Mateo_0And5_True_OK_Test()
        {
            var isBetween = "Mateo".IsBetween(0, 5);
            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void IsBetween_Nico_5And10_False_OK_Test()
        {
            var isBetween = "Nico".IsBetween(5, 10);
            Assert.IsFalse(isBetween);
        }

        [TestMethod]
        public void IsAlphaNumeric_Juandi_True_OK_Test()
        {
            var isAlphaNumeric = "Juandi".IsAlphaNumeric();
            Assert.IsTrue(isAlphaNumeric);
        }

        [TestMethod]
        public void IsAlphaNumeric_Scribble_False_OK_Test()
        {
            var scribble = "~./-=>";
            var isAlphaNumeric = scribble.IsAlphaNumeric();
            Assert.IsFalse(isAlphaNumeric);
        }

        [TestMethod]
        public void IsAlphaNumeric_Juandi0402_True_OK_Test()
        {
            var isAlphaNumeric = "Juandi0402".IsAlphaNumeric();
            Assert.IsTrue(isAlphaNumeric);
        }

        [TestMethod]
        public void IsAlphaNumeric_EmptyString_False_OK_Test()
        {
            var isAlphaNumeric = "".IsAlphaNumeric();
            Assert.IsFalse(isAlphaNumeric);
        }

        [TestMethod]
        public void HasUpper_EmptyString_False_OK_Test()
        {
            var hasUpper = "".HasUpper();
            Assert.IsFalse(hasUpper);
        }

        [TestMethod]
        public void HasUpper_UppercaseLetter_True_OK_Test()
        {
            var hasUpper = "T".HasUpper();
            Assert.IsTrue(hasUpper);
        }

        [TestMethod]
        public void HasUpper_LowercaseLetter_False_OK_Test()
        {
            var hasUpper = "t".HasUpper();
            Assert.IsFalse(hasUpper);
        }

        [TestMethod]
        public void HasUpper_3Upper_Word_False_OK_Test()
        {
            var hasUpper = "Word".HasUpper(3);
            Assert.IsFalse(hasUpper);
        }

        [TestMethod]
        public void HasUpper_0Upper_Word_False_OK_Test()
        {
            var hasUpper = "Word".HasUpper(0);
            Assert.IsFalse(hasUpper);
        }

        [TestMethod]
        public void HasUpper_5Upper_WORD_False_OK_Test()
        {
            var hasUpper = "WORD".HasUpper(5);
            Assert.IsFalse(hasUpper);
        }

        [TestMethod]
        public void HasUpper_0Upper_word_True_OK_Test()
        {
            var hasUpper = "word".HasUpper(0);
            Assert.IsTrue(hasUpper);
        }

        [TestMethod]
        public void HasNumber_EmptyString_False_OK_Test()
        {
            var hasNumber = "".HasNumber();
            Assert.IsFalse(hasNumber);
        }

        [TestMethod]
        public void HasNumber_StringWithNumber_True_OK_Test()
        {
            var hasNumber = "Mkjenrgngr4kjgnr".HasNumber();
            Assert.IsTrue(hasNumber);
        }
    }
}