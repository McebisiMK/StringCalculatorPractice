using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var delimiter = new List<char> { ',', '\n' };
            if (numbers.StartsWith("//"))
            {
                delimiter.Add(char.Parse(numbers.Substring(2, 1)));
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
            }

            var stringNumber = numbers.Split(delimiter.ToArray());
            var negatives = stringNumber.Where(number => int.Parse(number) < 0);
            if (negatives.Count() > 0)
            {
                HandleNegativeNumbers(negatives);
            }
            return stringNumber.Select(number => int.Parse(number)).Where(number => number <= 1000).Sum();
        }

        private static void HandleNegativeNumbers(IEnumerable<string> negatives)
        {
            var allNegatives = string.Join(" ", negatives.ToArray());
            throw new Exception($"Negatives not allowed {allNegatives}");
        }
    }
}