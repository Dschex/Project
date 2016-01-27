namespace Calculator
{
    public interface ISubtraction
    {
        double Subtract(double value1, double value2);
    }
    public class Subtraction: ISubtraction
    {
        public double Subtract(double value1, double value2)
        {
            return (value1 - value2);
        }
    }
}
