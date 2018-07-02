
using NUnit.Framework;
using StringCalculatorKata;

namespace ClassLibrary1StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenEmptyString_ShouldReturnZero(string numbers)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(numbers);

            //--------------------Assert------------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
        [TestCase("10", 10)]
        [TestCase("5", 5)]
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
        [TestCase("4,6,5", 15)]
        [TestCase("20,100,45,52", 217)]
        public void Add_GivenStringOfNumbersSeparatedByComma_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,10", 13)]
        [TestCase("5\n50,10\n45", 110)]
        [TestCase("50\n50,2\n58,65", 225)]
        public void Add_GivenStringOfNumbersSeparatedByNewlineAndComma_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//#\n100#10#20", 130)]
        [TestCase("//&\n88&99&10&100", 297)]
        public void Add_GivenStringOfNumbersSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n2;1001;", 2)]
        [TestCase("//**\n1000**1001**12", 1012)]
        [TestCase("//&&&\n15&&&1010&&&47&&&78", 140)]
        public void Add_GivenStringOfNumbersOneIsGreaterThan1000_ShouldIgnoreTheNumberGreaterThan100AndReturnSumOfOtherNumbers(string number, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(number);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[;;;][,,,]\n87;;;54,,,23;;;10,,,6", 180)]
        [TestCase("//[&&&&][$$$$]\n88&&&&99$$$$10", 197)]
        public void Add_GivenStringOfNumbersSeparatedByMultipleSpecifiedDelimitersWithMoreThanTwoCharacters_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
        {
            //--------------------Arrange----------------------------
            var stringCalculator = CreateStringCalculator();

            //--------------------Act--------------------------------
            var actual = stringCalculator.Add(numbers);

            //--------------------Assert------------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
