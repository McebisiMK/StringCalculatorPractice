using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_07_24
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var delimiter = new List<string> { ",", "\n" };
                numbers = GetNumberWithDelimitersOnly(numbers, delimiter);

                var listOfNumbers = numbers.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(number => int.Parse(number));
                HandleNegatives(listOfNumbers);

                return listOfNumbers.Where(number => number <= 1000).Sum();
            }
            return 0;
        }

        private string GetNumberWithDelimitersOnly(string numbers, List<string> delimiter)
        {
            if (numbers.StartsWith("//"))
            {
                if (numbers.Contains("["))
                {
                    var delimiters = numbers.Substring(3, numbers.LastIndexOf("]") - 3).Split("][".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    delimiter.AddRange(delimiters);
                }
                delimiter.Add(numbers.Substring(2, 1));

                return numbers.Substring(numbers.IndexOf("\n"));
            }
            return numbers;
        }

        private void HandleNegatives(IEnumerable<int> listOfNumbers)
        {
            if (listOfNumbers.Any(number => number < 0))
            {
                var negatives = string.Join(" ", listOfNumbers.Where(number => number < 0));
                throw new Exception($"Negatives are not allowed {negatives}");
            }
        }
    }
}