using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
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
                    numbers = ExtractValidNumbers(numbers, delimiter);
                }

                var listOfNumbers = numbers.Split(delimiter.ToArray(), StringSplitOptions.None).Select(n => int.Parse(n));
                HandleNegativeNumbers(listOfNumbers);

                return listOfNumbers.Where(number => number <= 1000).Sum();
            }
            return 0;
        }

        private static string ExtractValidNumbers(string numbers, List<string> delimiter)
        {
            if (numbers[2].Equals('['))
            {
                var listOfDelimiters = numbers.Substring(3, numbers.LastIndexOf(']') - 3).Replace("][", ",").Split(',');
                delimiter.AddRange(listOfDelimiters);
                numbers = numbers.Substring(numbers.IndexOf("\n") + 1);

                return numbers;
            }
            delimiter.Add(numbers[2].ToString());
            numbers = numbers.Substring(4);

            return numbers;
        }

        private static void HandleNegativeNumbers(IEnumerable<int> listOfNumbers)
        {
            var negatives = listOfNumbers.Where(number => number < 0);
            if (negatives.Count() > 0)
            {
                var allNegatives = string.Join(" ", negatives.ToArray());
                throw new Exception($"Negatives not allowed {allNegatives}");
            }
        }
    }
}