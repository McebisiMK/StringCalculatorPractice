using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_07_31
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var delimiters = new List<string> { ",", "\n" };
                numbers = GetSplitted(numbers, delimiters);
                var listOfNumbers = GetAll(numbers, delimiters);
                HandleNegatives(listOfNumbers);

                return listOfNumbers.Where(number => number<=1000).Sum();
            }
            return 0;
        }
        
        private string GetSplitted(string numbers, List<string> delimiters)
        {
            var numbersWithDelimiters = numbers;
            if (numbers.StartsWith("//"))
            {
                numbersWithDelimiters = numbers.Substring(numbers.IndexOf("\n"));
                if (numbers.Contains("["))
                {
                    int startIndex = numbers.IndexOf("[");
                    var listOfDelimiter = numbers.Substring(startIndex, numbers.LastIndexOf("]") - startIndex)
                                                    .Split("][".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    delimiters.AddRange(listOfDelimiter);

                    return numbersWithDelimiters;
                }
                var delimiter = numbers.Substring(2, 1);
                delimiters.Add(delimiter);
            }
            return numbersWithDelimiters;
        }

        private IEnumerable<int> GetAll(string numbers, List<string> delimiters)
        {
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