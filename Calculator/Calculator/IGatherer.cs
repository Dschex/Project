namespace Calculator
{
    public interface IGatherer
    {
        int ParseToInteger(string userString);
        string MathFunction(string userString);
        int GetTotal(string operation, int number1, int number2);
    }
}
