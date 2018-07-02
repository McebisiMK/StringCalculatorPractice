using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class NumberExtraction: INumberExtraction
    {
        public IEnumerable<int> ExtractValidNumbers(string numbers)
        {
            var listOfNumbers = new List<int>();
            var stringNumbers = Regex.Matches(numbers, @"(\d+)");

            foreach (var number in stringNumbers)
            {
                listOfNumbers.Add(Int32.Parse(number.ToString()));
            }

            return listOfNumbers.Where(x => x <= 1000);
        }
    }
}
