using System;

namespace Calculator
{
   public class Calculate
    {
        private IGatherer _gatherer;

       public Calculate()
       {
           
       }
       public Calculate(IGatherer gatherer)
        {
            _gatherer = gatherer;
        }
        public void Run()
        {
            _gatherer = new Gatherer();

            //Variables 
            string total;
            double convertedNumber1;
            double convertedNumber2;
            string userInputValue1 = string.Empty;
            string userInputValue2 = string.Empty;
            string userInputFunction = string.Empty;
            string operation = String.Empty;

            try
            {
                Console.WriteLine(
                    "Would you like to ADD, SUBTRACT, MULTIPLY or DIVIDE ? \r\nType A to Add, S to Substract, M to Multiply or D to Divide");

                //Call MathFunction and assign it to variable "operation"
                userInputFunction = Console.ReadLine();
                operation = _gatherer.MathFunction(userInputFunction); 
                
                //Convert userString to integer
                Console.WriteLine("Please enter the first number.");
                userInputValue1 = Console.ReadLine();
                convertedNumber1 = _gatherer.ParseToDouble(userInputValue1);

                Console.WriteLine("Please enter the second number.");
                userInputValue2 = Console.ReadLine();
                convertedNumber2 = _gatherer.ParseToDouble(userInputValue2);
                _gatherer.ParseToDouble(userInputValue2);

                //Get total base on operation selected.
                total = _gatherer.GetTotal(operation, convertedNumber1, convertedNumber2);

                //Display total
                Console.WriteLine(total);
                Console.ReadLine();
            }

            catch (DivideByZeroException)
            {
                Console.Write($"Remember division by zero is not allowed.  Let's start over.\r\n");
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't know what you want. Let's start over.");
                Run();
            }
        }
    }
}