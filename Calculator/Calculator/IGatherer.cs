using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IGatherer
    {
        int ParseToInteger(string userString);
        string MathFunction(string userString);
        int GetTotal(string operation, int number1, int number2);
    }
}
