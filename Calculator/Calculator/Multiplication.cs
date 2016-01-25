namespace Calculator
{
    public interface IMultiplication
    {
        int Multiply(int value1, int value2);
    }
    public class Multiplication: IMultiplication
    {
        public int Multiply(int value1, int value2)
        {
            return (value1 * value2);
        }
    }
}
