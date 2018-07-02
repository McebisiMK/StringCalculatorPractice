using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata_Practice
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            //--------------------Arrange----------------------------
            var number = "";
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("10",10)]
        [TestCase("5",5)]
        public void Add_GivenOnlyOneNumberAsString_ShouldReturnThatNumber(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("4,6", 10)]
        [TestCase("20,100",120)]
        public void Add_GivenStringOfTwoNumbersSeparatedByComma_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2",3)]
        [TestCase("5\n50",55)]
        [TestCase("50\n50",100)]
        public void Add_GivenStringOfTwoNumbersSeparatedByNewline_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,10", 13)]
        [TestCase("5\n50,10", 65)]
        [TestCase("50\n50,2", 102)]
        public void Add_GivenStringOfTwoNumbersSeparatedByNewlineAndComma_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2",3)]
        [TestCase("//#\n100#10",110)]
        [TestCase("//&\n88&99",187)]
        public void Add_GivenStringOfTwoNumbersSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n2;1001;", 2)]
        [TestCase("//;\n1000;1001;", 1000)]
        [TestCase("//;\n15;1010;", 15)]
        public void Add_GivenStringOfTwoNumbersOneIsGreaterThan1000_ShouldIgnoreTheNumberGreaterThan100AndReturnSumOfOtherNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[;][,]\n87;54,23;10,6",180)]
        [TestCase("//[&][$]\n88&99$10", 197)]
        public void Add_GivenStringOfNumbersSeparatedByMultipleSpecifiedDelimiters_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[**][%%]\n1**2%%3", 6)]
        [TestCase("//[;;;][,,,]\n87;;;54,,,23;;;10,,,6", 180)]
        [TestCase("//[&&&&][$$$$]\n88&&&&99$$$$10", 197)]
        public void Add_GivenStringOfNumbersSeparatedByMultipleSpecifiedDelimitersWithMoreThanTwoCharacters_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
