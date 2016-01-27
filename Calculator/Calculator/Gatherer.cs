using System;

namespace Calculator
{
    public interface IGatherer
    {
        double ParseToDouble(string userString);
        string MathFunction(string userString);
        double GetTotal(string operation, double number1, double number2);
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
        public double ParseToDouble(string userString)
        {
            var parsedValue = double.Parse(userString);

            if (parsedValue >= double.MaxValue || parsedValue <= double.MinValue)
            {
                throw new FormatException();
            }
            return parsedValue;
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

        public double GetTotal(string operation, double number1, double number2)
        {
            _addition = new Addition();
            _subtraction = new Subtraction();
            _multiplication = new Multiplication();
            _division = new Division();

            switch (operation)
            {
                case "A":
                    return _addition.Add(number1, number2);
                case "S":
                    return _subtraction.Subtract(number1, number2);
                case "M":
                    return _multiplication.Multiply(number1, number2);
                case "D":
                    return _division.Divide(number1, number2);
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}