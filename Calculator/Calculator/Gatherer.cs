using System;

namespace Calculator
{
    public interface IGatherer
    {
        double ParseToDouble(string userString);
        string MathFunction(string userString);
        string GetTotal(string operation, double number1, double number2);
    }

    public class Gatherer: IGatherer
    {
        private IAddition _addition = new Addition();
        private ISubtraction _subtraction = new Subtraction();
        private IMultiplication _multiplication = new Multiplication();
        private IDivision _division = new Division();

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

        public string GetTotal(string operation, double number1, double number2)
        {
            if (operation == "A")
            {
                var total = _addition.Add(number1, number2);
                return ($"The sum of {number1} + {number2} is {total}");
            }
            if (operation == "S")
            {
                var total = _subtraction.Subtract(number1, number2);
                return ($"The difference of { number1} - { number2} is { total}");
            }
            if (operation == "M")
            {
                var total = _multiplication.Multiply(number1, number2);
                return ($"The product of {number1} * {number2} is {total}");
            }
            if (operation == "D")
            {
                var total = _division.Divide(number1, number2);
                return ($"The quotient of {number1} / {number2} is {total}");
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}