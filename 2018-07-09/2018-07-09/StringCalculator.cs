using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_07_09
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var delimiter = new List<string> { ",", "\n" };
                if (numbers.StartsWith("//"))
                {
                    numbers = ExtractNumbers(numbers, delimiter);
                }
                var listOfNumbers = numbers.Split(delimiter.ToArray(),StringSplitOptions.RemoveEmptyEntries)
                                           .Select(number => int.Parse(number));
                HandleNegatives(listOfNumbers);

                return listOfNumbers.Where(number => number <= 1000).Sum();
            }

            return 0;
        }

        private string ExtractNumbers(string numbers, List<string> delimiter)
        {
            if (numbers.Contains("["))
            {
                var listOfDelimiters = numbers.Substring(3, numbers.LastIndexOf("]") - 3).Split("][".ToArray());
                delimiter.AddRange(listOfDelimiters);

                return numbers.Substring(numbers.LastIndexOf("]") + 1);
            }
            delimiter.Add(numbers[2].ToString());

            return numbers.Substring(3);
        }

        private void HandleNegatives(IEnumerable<int> listOfNumbers)
        {
            if (listOfNumbers.Any(number => number < 0))
            {
                var negatives = listOfNumbers.Where(number => number < 0).ToArray();
                var stringOfNegatives = string.Join(" ", negatives);
                throw new Exception($"Negatives not allowed {stringOfNegatives}");
            }
        }
    }
}