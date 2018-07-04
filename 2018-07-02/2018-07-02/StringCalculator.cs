using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_07_02
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            
            var delimiter = new char[] { ',', '\n' }.ToList();
            if (numbers.StartsWith("//"))
            {
                delimiter.Add(numbers[2]);
                numbers = numbers.Substring(4);
            }
            var stringOfNumbers = numbers.Split(delimiter.ToArray());
            var negativeNumbers = stringOfNumbers.Where(number => int.Parse(number) < 0);
            HandleNegativeNumbers(negativeNumbers);

            return stringOfNumbers.Sum(number => int.Parse(number));
        }

        private static void HandleNegativeNumbers(IEnumerable<string>negativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                var negatives = string.Join(" ", negativeNumbers.ToArray());
                throw new Exception($"Negatives not allowed {negatives}");
            }
        }
    }
}