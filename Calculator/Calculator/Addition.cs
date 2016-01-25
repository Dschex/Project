namespace Calculator
{
    public interface IAddition
    {
        int Add(int value1, int value2);
    }

    public class Addition : IAddition
    {
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}