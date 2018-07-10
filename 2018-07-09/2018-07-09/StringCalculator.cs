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
                var delimiters = new List<string> { ",", "\n" };
                numbers = GetValidString(numbers, delimiters);
                var listOfNumbers = GetSplittedList(numbers, delimiters);
                HandleNegatives(listOfNumbers);

                return listOfNumbers.Where(number => number <= 1000).Sum();
            }

            return 0;
        }

        private string GetValidString(string numbers, List<string> delimiters)
        {
            if (numbers.Contains("["))
            {
                var listOfDelimiters = numbers.Substring(3, numbers.LastIndexOf("]") - 3).Split("][".ToArray());
                delimiters.AddRange(listOfDelimiters);

                return numbers.Substring(numbers.LastIndexOf("]") + 1);
            }
            else if (numbers.StartsWith("//") && numbers.Contains("[") == false)
            {
                delimiters.Add(numbers[2].ToString());

                return numbers.Substring(3);
            }
            return numbers;
        }

        private static IEnumerable<int> GetSplittedList(string numbers, List<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(number => int.Parse(number));
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