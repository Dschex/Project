namespace Calculator
{
    public interface IDivision
    {
        int Divide(int dividend, int divisor);
    }
    class Divison
    {
        public int Divide(int dividend, int divisor)
        {
            return (dividend/ divisor);
        }
    }
}
