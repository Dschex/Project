namespace Calculator
{
    public interface IMultiplication
    {
        double Multiply(double value1, double value2);
    }
    public class Multiplication: IMultiplication
    {
        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }
    }
}
