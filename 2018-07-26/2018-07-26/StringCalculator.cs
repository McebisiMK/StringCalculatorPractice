using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_07_26
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

        private string GetNumberWithDelimiter(string numbers, List<string> delimiters)
        {
            if (numbers.StartsWith("//"))
            {
                var numberWithDelimiter = numbers.Substring(numbers.IndexOf("\n"));
                if (numbers.Contains("["))
                {
                    var startIndex = numbers.IndexOf("[");
                    var listOfDelimiters = numbers.Substring(startIndex, numbers.LastIndexOf("]") - startIndex)
                                                    .Split("][".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    delimiters.AddRange(listOfDelimiters);

                    return numberWithDelimiter;
                }
                delimiters.Add(numbers.Substring(2, 1));

                return numberWithDelimiter;
            }
            return numbers;
        }

        private IEnumerable<int> GetSplitted(string numbers, List<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                        .Select(number => int.Parse(number));
        }

        private void HandleNegatives(IEnumerable<int> listOfNumbers)
        {
            if (listOfNumbers.Any(number => number < 0))
            {
                var negatives = listOfNumbers.Where(negative => negative < 0);
                var stringOfNegatives = string.Join(" ", negatives);
                throw new Exception($"Negatives are not allowed {stringOfNegatives}");
            }
        }
    }
}