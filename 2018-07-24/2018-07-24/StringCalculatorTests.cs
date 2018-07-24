using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_07_24
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenWhiteSpaceOrNull_ShouldReturnZero(string numbers)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("10",10)]
        [TestCase("100",100)]
        public void Add_GivenSingleNumberAsString_ShouldReturnThatNumberAsInteger(string numbers,int expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("10,100,55", 165)]
        [TestCase("10,100,85,69", 264)]
        public void Add_GivenNumbersSeparatedByComma_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n100,55,50", 215)]
        [TestCase("10\n100,85\n69,40", 304)]
        public void Add_GivenNumbersSeparatedByCommaAndNewline_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//***\n10***100***55***50", 215)]
        [TestCase("//^^^\n100^^^85^^^69^^^40", 294)]
        public void Add_GivenNumbersSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;-2", "-2")]
        [TestCase("//***\n10***-100***55***-50", "-100 -50")]
        [TestCase("//^^^\n-100^^^-85^^^-69^^^40", "-100 -85 -69")]
        public void Add_GivenNumbersSeparatedByAnyDelimiterContainingNegatives_ShouldReturnMessageAndListOfNegatives(string numbers, string expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            //----------------------Assert---------------------------
            var expectedMessage = $"Negatives are not allowed {expected}";
            Assert.AreEqual(expectedMessage, actual.Message);
        }

        [TestCase("//;\n2;1001", 2)]
        [TestCase("//***\n10***1008***55***50", 115)]
        [TestCase("//^^^\n1010^^^85^^^69^^^40", 194 )]
        public void Add_GivenNumbersSeparatedByAnyDelimiterContainingNumbergreater1000_ShouldReturnSumOfNumberNotgreaterThan1000(string numbers, int expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[;;;]\n2;;;2", 4)]
        [TestCase("//[***][%%%]\n10***1008%%%55***50", 115)]
        [TestCase("//[^^^][---]\n100^^^85---69^^^40---15", 309)]
        public void Add_GivenNumbersSeparatedByDelimiterInBrackets_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------------Assert---------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
