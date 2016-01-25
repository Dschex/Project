using System.Runtime.InteropServices;

namespace Calculator
{
    public interface IDivision
    {
        int Divide(int dividend, int divisor);
    }
    public class Divison: IDivision
    {
        public int Divide(int dividend, int divisor)
        {
            return (dividend/ divisor);
        }
    }
}
