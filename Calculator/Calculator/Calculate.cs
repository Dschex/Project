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
            int total;
            int convertedNumber1;
            int convertedNumber2;
            string userInputValue1 = string.Empty;
            string userInputValue2 = string.Empty;
            string userInputFunction = string.Empty;
            string operation = "S";

            try
            {
                Console.WriteLine("Would you like to ADD, SUBTRACT, or MULTIPLY ? \r\nType A to Add, S to Substract, or M to Multiply");

                //Call MathFunction and assign it to variable "operation"
                userInputFunction = Console.ReadLine();
                operation = GetMathFunction(userInputFunction);

                //Convert userString to integer
                Console.WriteLine("Please enter the first number.");
                userInputValue1 = Console.ReadLine();
                convertedNumber1 = GetConvertedNumber(userInputValue1);

                Console.WriteLine("Please enter the second number.");
                userInputValue2 = Console.ReadLine();
                convertedNumber2 = GetConvertedNumber(userInputValue2);

                //Get total base on operation selected.
                total = GetTotal(operation, convertedNumber1, convertedNumber2);

                if (operation == "A")
                {
                    Console.WriteLine($"The sum of {convertedNumber1} + {convertedNumber2} is {total} ");
                    Console.ReadLine();
                }
                if (operation == "S")
                {
                    Console.WriteLine($"The difference of {convertedNumber1} - {convertedNumber2} is {total} ");
                    Console.ReadLine();
                }
                if (operation == "M")
                {
                    Console.WriteLine($"The product of {convertedNumber1} * {convertedNumber2} is {total} ");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't know what you want. Let's start over.");
                Run();
            }

        }

       public string GetMathFunction(string userInputFunction)
       {
           var userfunction = _gatherer.MathFunction(userInputFunction);
           return userfunction;
       }

       public int GetConvertedNumber(string userInputValue)
       {
          return _gatherer.ParseToInteger(userInputValue);
       }

       public int GetTotal(string operation, int convertedNumber1, int convertedNumber2)
        {
           return _gatherer.GetTotal(operation, convertedNumber1, convertedNumber2);
       }
    }
}