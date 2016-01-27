namespace Calculator
{
    public interface IAddition
    {
        double Add(double value1, double value2);
    }

    public class Addition : IAddition
    {
        public double Add(double value1, double value2)
        {
            return (value1 + value2);
        }
    }
}