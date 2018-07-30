using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_07_30
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenNullOrWhiteSpace_ShouldReturnZero(string numbers)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator(); 

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("10",10)]
        [TestCase("100",100)]
        public void Add_GivenSingleNumberAsString_ShouldReturnThatNumberAsInteger(string numbers,int expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("10,45,100", 155)]
        [TestCase("100,25,36,69", 230)]
        public void Add_GivenStringOfNumbersSeparatedByComma_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n45,100\n52", 207)]
        [TestCase("100\n25,36\n69,100", 330)]
        public void Add_GivenStringOfNumbersSeparatedByCommaAndNewline_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//%\n10%45%100%52", 207)]
        [TestCase("//*\n100*25*36*69*100", 330)]
        public void Add_GivenStringOfNumbersSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,-3", "-3")]
        [TestCase("//%\n-10%45%100%-52", "-10 -52")]
        [TestCase("//*\n100*-25*-36*-69*100", "-25 -36 -69")]
        public void Add_GivenStringOfNumbersDelimitersContainingNegatives_ShouldThrowExceptionAndReturnListOfNegatives(string numbers, string expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            //---------------------Assert----------------------------
            var expectedMessage = $"Negatives are not allowed {expected}";
            Assert.AreEqual(expectedMessage, actual.Message);
        }

        [TestCase("1\n2,1001", 3)]
        [TestCase("//%\n2018%10%45%100%2009", 155)]
        [TestCase("//*\n100*2008*9623*2589*100", 200)]
        public void Add_GivenStringOfNumbersDelimitersContainingNumbersGreaterThan1000_ShouldReturnSumOfNumberNotGreaterThan1000(string numbers, int expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[;]\n1;2;3", 6)]
        [TestCase("//[%%]\n10%%45%%100%%52", 207)]
        [TestCase("//[***][^^^]\n100***25^^^36***69^^^100", 330)]
        public void Add_GivenStringOfNumbersSeparatedBySpecifiedDelimiterInBrackets_ShouldReturnSumOfThoseNumber(string numbers, int expected)
        {
            //---------------------Arrange---------------------------
            var stringCalculator = CreateStringCalculator();

            //---------------------Act-------------------------------
            var actual = stringCalculator.Add(numbers);

            //---------------------Assert----------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
