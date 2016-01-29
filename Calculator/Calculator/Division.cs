using System;

namespace Calculator
{
    public interface IDivision
    {
        double Divide(double dividend, double divisor);
    }
    public class Division: IDivision
    {
        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            return dividend / divisor;
        }
    }
}
