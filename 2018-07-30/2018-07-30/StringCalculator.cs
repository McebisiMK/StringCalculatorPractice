using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_07_30
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {

            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var delimiters = new List<string> { ",", "\n" };
                numbers = GetNumberWithDelimiter(numbers, delimiters);
                var listOfNumbers = GetSplitted(numbers, delimiters);
                HandleNegatives(listOfNumbers);
                return listOfNumbers.Where(number => number <= 1000).Sum();
            }
            return 0;
        }

        private void HandleNegatives(IEnumerable<int> listOfNumbers)
        {
            if (listOfNumbers.Any(number => number < 0))
            {
                var negatives = listOfNumbers.Where(number => number < 0);
                throw new Exception($"Negatives are not allowed {string.Join(" ", negatives)}");
            }
        }

        private IEnumerable<int> GetSplitted(string numbers, List<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(number => int.Parse(number));
        }

        private string GetNumberWithDelimiter(string numbers, List<string> delimiters)
        {
            var numbersSeratedByDelimiter = numbers;
            if (numbers.StartsWith("//"))
            {
                numbersSeratedByDelimiter = numbers.Substring(numbers.IndexOf("\n"));
                if (numbers.Contains("["))
                {
                    var startPosition = numbers.IndexOf("[") + 1;
                    var listOfDelimiters = numbers.Substring(startPosition, numbers.LastIndexOf("]") - startPosition)
                                                    .Split("][".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    delimiters.AddRange(listOfDelimiters);

                    return numbersSeratedByDelimiter;
                }
                var delimiter = numbers.Substring(2, 1);
                delimiters.Add(delimiter);
            }
            return numbersSeratedByDelimiter;
        }
    }
}