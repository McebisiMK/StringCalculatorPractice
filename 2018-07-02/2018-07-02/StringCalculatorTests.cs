using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_07_02
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidString_ShouldReturnZero(string numbers)
        {
            //----------------------Arrange---------------------------
            var stringCalculator = new StringCalculator();

            //----------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert----------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("100",100)]
        [TestCase("125",125)]
        public void Add_GivenSingleNumberAsString_ShouldReturnNumberAsInteger(string numbers,int expected)
        {
            //----------------------Arrange---------------------------
            var stringCalculator = new StringCalculator();

            //----------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,8,10", 20)]
        [TestCase("5,78,96,25", 204)]
        public void Add_GivenStringOfNumbersSeparatedByComma_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //----------------------Arrange---------------------------
            var stringCalculator = new StringCalculator();

            //----------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("2,8\n10,15", 35)]
        [TestCase("5\n78,96\n25,25", 229)]
        public void Add_GivenStringOfNumbersSeparatedByCommaAndNewline_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //----------------------Arrange---------------------------
            var stringCalculator = new StringCalculator();

            //----------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        //[TestCase("2,8\n10,15", 35)]
        //[TestCase("5\n78,96\n25,25", 229)]
        public void Add_GivenStringOfNumbersSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //----------------------Arrange---------------------------
            var stringCalculator = new StringCalculator();

            //----------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }
        [TestCase("-8", "Negatives not allowed -8")]
        [TestCase("-8,2,-9", "Negatives not allowed -8 -9")]
        [TestCase("//%\n-8%9%-11", "Negatives not allowed -8 -11")]
        public void Add_GivenStringOfNumbersContainingNegativeNumber_ShouldThrowExceptionAllNegativeNumbersThatWerePassed(string number, string expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = new StringCalculator();

            //-------------------Act------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(number));

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual.Message);

        }

    }
}
