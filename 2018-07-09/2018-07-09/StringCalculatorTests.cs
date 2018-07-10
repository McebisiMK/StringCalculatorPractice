using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_07_09
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidString_ShouldReturnZero(string numbers)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("10",10)]
        [TestCase("100",100)]
        public void Add_GivenSingleNumberAsString_ShouldReturnThatNumberAsInteger(string numbers, int expected)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("15,85,56", 156)]
        [TestCase("45,85,20,36", 186)]
        public void Add_GivenNumbersAsStringSeparatedByComma_ShouldReturnSumOfNumbersAsInteger(string numbers, int expected)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("15\n85,56\n44", 200)]
        [TestCase("45\n85,20\n36,24", 210)]
        public void Add_GivenNumbersAsStringSeparatedByCommaAndNewline_ShouldReturnSumOfNumbersAsInteger(string numbers, int expected)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//*\n100*102*52", 254)]
        [TestCase("//%\n123%25%36%98", 282)]
        public void Add_GivenNumbersAsStringSeparatedBySpecifiedDelimiter_ShouldReturnSumOfNumbersAsInteger(string numbers, int expected)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("2,-8", "-8")]
        [TestCase("//*\n100*-52*52*-102", "-52 -102")]
        [TestCase("\n-123,-25\n1008,-36\n98", "-123 -25 -36")]
        public void Add_GivenNumbersAsStringSeparatedByAnyDelimiterContaingNegatives_ShouldReturnThrowExceptionWithAllNegatives(string numbers, string negatives)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            //-----------------Assert----------------------------
            var expected = $"Negatives not allowed {negatives}";
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("2,1001", 2)]
        [TestCase("//*\n100*1002*52,102", 254)]
        [TestCase("\n123,25\n1008,36\n98", 282)]
        public void Add_GivenNumbersAsStringSeparatedByAnyDelimiterContaingNumbersGreaterThan1000_ShouldReturnSumOfNumberLessOrEqual1000(string numbers, int expected)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[;]\n1;2", 3)]
        [TestCase("//[**][%%]\n100**102%%52", 254)]
        [TestCase("//[###][''']\n123###25'''36###98'''18", 300)]
        public void Add_GivenNumbersAsStringSeparatedBySpecifiedDelimitersInBrackets_ShouldReturnSumOfNumbersAsInteger(string numbers, int expected)
        {
            //-----------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //-----------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //-----------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
