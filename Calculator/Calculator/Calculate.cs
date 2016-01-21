using System;
using System.Runtime.CompilerServices;

namespace Calculator
{
    public class Calculate
    {
        private IAddition _addition;
        private IGatherer _gatherer;
        private ISubtraction _subtraction ;

        public Calculate()
        {
        }

        public Calculate(IGatherer gatherer, IAddition addition, ISubtraction subtraction)
        {
            _gatherer = gatherer;
            _addition = addition;
            _subtraction = subtraction;
        }

        public void Run()
        {
            int total = 0;
            int convertedNumber1 = 0;
            int convertedNumber2 = 0;

            Console.WriteLine("Would you like to ADD or SUBTRACT? \r\nType A to Add, and S to Substract");
            
            //Call MathFunction and assign it to variable Operation
            string userInputFunction = Console.ReadLine();
            string operation = MathFunction(userInputFunction);

            Console.WriteLine("Please enter the first number: ");
            
            //Call Gatherer to return parsed integers and add them into a list
            string userInputValue1 = Console.ReadLine();
            try
            {
                convertedNumber1 = _gatherer.GatherInteger(userInputValue1);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"I am restarting the program.");
                Run();
            }



            Console.WriteLine("Please enter the second number: ");
            string userInputValue2 = Console.ReadLine();
            convertedNumber2 = _gatherer.GatherInteger(userInputValue2);

            //Wrap Gatherer in a Continue Y N loop (Version 2.0) maybe a list or array

            //Using operation, call correct Operation Class to do math

            if (operation == "A")
            {
                total = _addition.Add(convertedNumber1, convertedNumber2);
                //Return total and display in console write line
                Console.WriteLine($"The total of {convertedNumber1} + {convertedNumber2} = {total}");
                Console.ReadLine();
            }
            if (operation == "S")
            {
                total = _subtraction.Subtract(convertedNumber1, convertedNumber2);
                //Return total and display in console write line
                Console.WriteLine($"The total of {convertedNumber1} - {convertedNumber2} = {total}");
                Console.ReadLine();
            }
            else
            {
                Run();
            }
        }

        public string MathFunction(string userString)
        {
            if (userString.ToUpper() == "A"|| userString.ToUpper() =="ADD")
            {
                return "A";
            }
            if (userString.ToUpper() == "S" || userString.ToUpper() == "SUBTRACT")
            {
                return "S";
            }
            else
            {
               Console.WriteLine("I don't understand what math function you want. Let's start again. \r\n");
               return null;

            }
        }

        public void CallGatherer(string userInput)
        {
            try
            {
              _gatherer.GatherInteger(userInput);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"I am restarting the program.");
                //Run();
            }
        }
    }
}