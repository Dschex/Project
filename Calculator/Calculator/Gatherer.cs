using System;

namespace Calculator
{
    public interface IGatherer
    {
        int ParseToInteger(string userString);
        string MathFunction(string userString);
        int GetTotal(string operation, int number1, int number2);
    }


    public class Gatherer: IGatherer
    {
        private IAddition _addition;
        private ISubtraction _subtraction;
        private IMultiplication _multiplication;
        private IDivision _division;

        public Gatherer()
        {

        }

        public Gatherer(IAddition addition, ISubtraction subtraction, IMultiplication multiplication, IDivision division)
        {
            _addition = addition;
            _subtraction = subtraction;
            _multiplication = multiplication;
            _division = division;
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
                case "M":
                case "MULTIPLY":
                    return "M";
                case "D":
                case "DIVIDE":
                    return "D";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int GetTotal(string operation, int number1, int number2)
        {
            _addition = new Addition();
            _subtraction = new Subtraction();
            _multiplication = new Multiplication();
            _division = new Divison();

            switch (operation)
            {
                case "A":
                    return  _addition.Add(number1, number2);
                case "S":
                    return  _subtraction.Subtract(number1, number2);
                case "M":
                    return  _multiplication.Multiply(number1, number2);
                case "D":
                    return _division.Divide(number1, number2);
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}