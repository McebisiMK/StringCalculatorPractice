using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_08_01
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var delimiters = GetDelimiter(numbers);
                var listOfNumbers = GetNumbers(numbers, delimiters);
                HandleNegatives(listOfNumbers);

                return listOfNumbers.Where(number => number <= 1000).Sum();
            }
            return 0;
        }

        private IEnumerable<string> GetDelimiter(string numbers)
        {
            var delimiters = new List<string>() { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                if (numbers.Contains("["))
                {
                    int startIndex = numbers.IndexOf("[");
                    var listOfDelimiter = numbers.Substring(startIndex, numbers.LastIndexOf("]") - startIndex)
                                                    .Split("][".ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    return listOfDelimiter;
                }
                 delimiters.Add(numbers.Substring(2, 1));
            }
            return delimiters;
        }

        private IEnumerable<int> GetNumbers(string numbers, IEnumerable<string> delimiters)
        {
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Substring(numbers.IndexOf("\n"));
            }
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(number => int.Parse(number));
        }

        private void HandleNegatives(IEnumerable<int> listOfNumbers)
        {
            if (listOfNumbers.Any(number => number < 0))
            {
                var negatives = listOfNumbers.Where(number => number < 0);
                throw new Exception($"Negatives are not allowed {string.Join(" ", negatives)}");
            }
        }
    }
}