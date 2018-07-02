using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata_Practice
{
    public class StringCalculator
    {
        private INumberService _numberService;

        public StringCalculator():this(new NumbersService())
        {
        }

        public StringCalculator(NumbersService numbersService)
        {
            _numberService = numbersService;
        }

        public int Add(string numbers)
        {
            var listOfNumbers = _numberService.ExtractNumber(numbers);
            
            return listOfNumbers.Sum();
        }
    }
}