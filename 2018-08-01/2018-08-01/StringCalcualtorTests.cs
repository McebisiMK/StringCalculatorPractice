using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_08_01
{
    [TestFixture]
    public class StringCalcualtorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenEmptyOrNullWhiteSpace_ShouldReturnZero(string numbers)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestCase("1", 1)]
        [TestCase("13", 13)]
        [TestCase("1000", 1000)]
        public void Add_GivenSingleNumberAsString_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("10,100,1000,1000", 2110)]
        public void Add_GivenNumbersAsStringSeparatedByComma_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2,3\n4", 10)]
        [TestCase("10\n100,1000\n1000,20", 2130)]
        public void Add_GivenNumbersAsStringSeparatedByCommaAndNewLine_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//*\n1*2*3*4", 10)]
        [TestCase("//%\n10%100%1000%1000%20", 2130)]
        public void Add_GivenNumbersAsStringSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1,2", "-1")]
        [TestCase("\n1,-2,3\n-4", "-2 -4")]
        [TestCase("//%\n10%100%-1000%-1000%20", "-1000 -1000")]
        public void Add_GivenNumbersAsStringSeparatedByDelimiterContainingNegatives_ShouldThrowExceptionWithListOfNegatives(string numbers, string expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            //------------------------Assert--------------------------------
            var expectedMessage = $"Negatives are not allowed {expected}";
            Assert.AreEqual(expectedMessage, actual.Message);
        }

        [TestCase("2011,2", 2)]
        [TestCase("\n1,1001,3\n2009", 4)]
        [TestCase("//%\n10%100%11000%8000%20", 130)]
        public void Add_GivenNumbersAsStringSeparatedByDelimiterContainingNumbersGreaterThan1000_ShouldReturnSumOfThoseNotGreaterThan1000(string numbers, int expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[;]\n1;2", 3)]
        [TestCase("//[***]\n1***2***3***4", 10)]
        [TestCase("//[%%%][^^^]\n10%%%100^^^1000%%%1000^^^20", 2130)]
        public void Add_GivenNumbersAsStringSeparatedByDelimitersInBrackets_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //------------------------Arrange-------------------------------
            var stringCalculator = CreateStringCalculator();

            //------------------------Act-----------------------------------
            var actual = stringCalculator.Add(numbers);

            //------------------------Assert--------------------------------
            Assert.AreEqual(expected, actual);
        }

        private  StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
