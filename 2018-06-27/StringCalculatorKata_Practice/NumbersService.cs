using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculatorKata_Practice
{
    public class NumbersService : INumberService
    {
        public List<int> ExtractNumber(string numbers)
        {
            var listOfNumbers = new List<int>();
            var stringNumbers = Regex.Matches(numbers, @"(\d+)");

            foreach (var number in stringNumbers)
            {
                listOfNumbers.Add(Int32.Parse(number.ToString()));
            }

            return listOfNumbers;
        }
    }
}
