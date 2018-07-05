using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            if (Valid(numbers))
            {
                var delimiter = new List<char> { ',', '\n' };
                if (SpecifiedDelimiter(numbers))
                {
                    numbers = GetNumbersFromStringWithSpecifiedDelimiter(numbers, delimiter);
                }

                var stringNumber = numbers.Split(delimiter.ToArray());
                var negatives = stringNumber.Select(number => int.Parse(number)).Where(number => number < 0);
                if (NumbersContain(negatives))
                {
                    HandleNegativeNumbers(negatives);
                }
                return stringNumber.Select(number => int.Parse(number)).Where(number => number <= 1000).Sum();
            }

            return 0;
        }

        private static bool SpecifiedDelimiter(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static bool NumbersContain(IEnumerable<int> negatives)
        {
            return negatives.Count() > 0;
        }

        private static bool Valid(string numbers)
        {
            return !string.IsNullOrWhiteSpace(numbers);
        }

        private static string GetNumbersFromStringWithSpecifiedDelimiter(string numbers, List<char> delimiter)
        {
            delimiter.Add(char.Parse(numbers.Substring(2, 1)));
            numbers = numbers.Substring(numbers.IndexOf('\n') + 1);

            return numbers;
        }

        private static void HandleNegativeNumbers(IEnumerable<int> negatives)
        {
            var allNegatives = string.Join(" ", negatives.ToArray());
            throw new Exception($"Negatives not allowed {allNegatives}");
        }
    }
}