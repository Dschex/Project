using System;
using System.CodeDom;

namespace Calculator
{
    public class Gatherer: IGatherer
    {
        private IAddition _addition;
        private ISubtraction _subtraction;

        public Gatherer()
        {
            
        }
        public Gatherer(IAddition addition, ISubtraction subtraction)
        {
            _addition = addition;
            _subtraction = subtraction;
        }
        public int ParseToInteger(string userString)
       {
            //this will throw a FormatException if it cannot be Parsed into an int so no further exception handling needed
           return int.Parse(userString);
        }

        public string MathFunction(string userString)
        {
            switch (userString.ToUpper())
            {
                case "A":
                case "ADD":
                    return "A";
                case "S":
                case "SUBTRACT":
                    return "S";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int GetTotal(string operation, int number1, int number2)
        {
            _addition = new Addition();
            _subtraction = new Subtraction();

            if (operation == "A")
            {
                var total = _addition.Add(number1, number2);
                return total;
            }
            if (operation == "S")
            {
                var total = _subtraction.Subtract(number1, number2);
                return total;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            } 
        }
    }
}