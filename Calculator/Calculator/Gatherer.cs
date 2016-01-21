using System;
using System.CodeDom;

namespace Calculator
{
    public class Gatherer: IGatherer
    {
        public int GatherInteger(string userString)
        {
            ConvertToInteger convertedString = new ConvertToInteger();

            int convertedValue = 0;
            try
            {
                convertedValue = convertedString.ParseHelper(userString);
                return convertedValue;

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Write("Since that didn't work, let's start again. \r\n");
                throw new ArgumentOutOfRangeException(ex.Message);
            }
        }
    }
}