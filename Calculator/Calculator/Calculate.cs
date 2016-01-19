using System;
using System.Runtime.CompilerServices;

namespace Calculator
{
    public class Calculate
    {
        public IAddition _addition { get; set; }
        public IGatherer _gatherer { get; set; }
        public ISubtraction _subtraction { get; set; }

        public void Run()
        {
           string operation = String.Empty;

            Console.WriteLine("Would you like to ADD or SUBTRACT? \r\n Type A to Add, and S to Substract");
            operation = Console.ReadLine().ToUpper();

            if (operation == "A")
            {
                Console.Write("Please enter the first number: ");
                string inputValue1 = Console.ReadLine();

                Console.Write("Please enter the second number: ");
                string inputValue2 = Console.ReadLine();
                int convertedNumber1 = _gatherer.GatherInteger(inputValue1);
                int convertedNumber2 = _gatherer.GatherInteger(inputValue2);

                Console.WriteLine(_addition.Adds(convertedNumber1, convertedNumber2));
            }
            else if (operation == "S")
            {
                Console.Write("Please enter the first number: ");
                string inputValue1 = Console.ReadLine();

                Console.Write("Please enter the second number: ");
                string inputValue2 = Console.ReadLine();
                int convertedNumber1 = _gatherer.GatherInteger(inputValue1);
                int convertedNumber2 = _gatherer.GatherInteger(inputValue2);

                Console.WriteLine(_subtraction.Subtract(convertedNumber1, convertedNumber2));
            }

        }
    }
}
