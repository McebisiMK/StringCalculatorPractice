using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_07_26
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenNullOrWhiteSpace_ShouldReturnZero(string numbers)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------------Assert-----------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("10",10)]
        [TestCase("100",100)]
        public void Add_GivenSingleNumberAsString_ShouldReturnThatNumberAsInteger(string numbers,int expected)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("10\n12,25", 47)]
        [TestCase("100\n25,85\n69", 279)]
        public void Add_GivenNumbersSeparatedByNewlineAndComma_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//#\n10#12#25", 47)]
        [TestCase("//*\n100*25*85*69", 279)]
        public void Add_GivenNumbersSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;-2", "-2")]
        [TestCase("//#\n-10#12#-25", "-10 -25")]
        [TestCase("//*\n100*-25*-85*69", "-25 -85")]
        public void Add_GivenNumbersSeparatedBySpecifiedDelimiterContainingNegatives_ShouldThrowExceptionWithListOfNegatives(string numbers, string expected)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = Assert.Throws<Exception>(()=> stringCalculator.Add(numbers));

            //-----------------------Assert-----------------------
            var expectedMessage = $"Negatives are not allowed {expected}";
            Assert.AreEqual(expectedMessage, actual.Message);
        }

        [TestCase("//;\n1;1001", 1)]
        [TestCase("//#\n1010#1000#25", 1025)]
        [TestCase("//*\n100*2008*2018*69", 169)]
        public void Add_GivenNumbersSeparatedBySpecifiedDelimiterContainingNumberGreaterThan1000_ShouldReturnSumOfNumbersNotGreaterThan1000(string numbers, int expected)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[;]\n1;1001", 1)]
        [TestCase("//[###]\n10###1000###25", 1035)]
        [TestCase("//[***][%%%]\n100***2008%%%2018***69", 169)]
        public void Add_GivenNumbersSeparatedByDelimiterInBrackets_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //-----------------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------------Act--------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
