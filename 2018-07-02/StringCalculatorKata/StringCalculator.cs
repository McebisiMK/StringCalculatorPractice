using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private INumberExtraction _numberExtraction;

        public StringCalculator() : this(new NumberExtraction())
        {
        }

        public StringCalculator(NumberExtraction numberExtraction)
        {
            _numberExtraction = numberExtraction;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            var listOfNumbers = _numberExtraction.ExtractValidNumbers(numbers);

            return listOfNumbers.Sum();
        }
    }
}