namespace Calculator
{
    public interface ISubtraction
    {
        int Subtract(int value1, int value2);
    }
    public class Subtraction: ISubtraction
    {
        public int Subtract(int value1, int value2)
        {
            return value1 - value2;
        }
    }
}
