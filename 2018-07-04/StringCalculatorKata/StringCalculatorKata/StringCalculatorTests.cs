using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidString_ShouldReturnZero(string numbers)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("10",10)]
        [TestCase("100",100)]
        public void Add_GivenSingleNumberAsString_ShouldReturnThatNumberAsInteger(string numbers,int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("10,78,100", 188)]
        [TestCase("100,20,50,30", 200)]
        public void Add_GivenNumbersAsStringSeparatedByComma_ShouldReturnSumOfThoseNumbersAsInteger(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = new StringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n78,100\n100", 288)]
        [TestCase("100\n20,50\n30,50", 250)]
        public void Add_GivenNumbersAsStringSeparatedByCommaAndNewline_ShouldReturnSumOfThoseNumbersAsInteger(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//^\n10^78^100^100", 288)]
        [TestCase("//*\n100*20*50*30*50", 250)]
        public void Add_GivenNumbersAsStringSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbersAsInteger(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-8", "Negatives not allowed -8")]
        [TestCase("-8,100,-9", "Negatives not allowed -8 -9")]
        [TestCase("//%\n-8%9%-11,45", "Negatives not allowed -8 -11")]
        public void Add_GivenStringOfNumbersContainingNegativeNumber_ShouldThrowExceptionAllNegativeNumbersThatWerePassed(string numbers, string expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;\n2;1001", 2)]
        [TestCase("10\n78,1010\n100", 188)]
        [TestCase("100,20,8888,30,50", 200)]
        public void Add_GivenNumbersAsStringHavingNumberGreaterThan1000SeparatedByDelimiter_ShouldReturnSumOfTheNumbersNotGreaterThan1000(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
