using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public interface INumberExtraction
    {
        IEnumerable<int> ExtractValidNumbers(string numbers);
    }
}
