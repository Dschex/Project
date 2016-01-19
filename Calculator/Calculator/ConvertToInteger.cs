using System;
using System.CodeDom;

namespace Calculator
{

    public class ConvertToInteger : IConvertToInteger
    {
        private string _string;

        public ConvertToInteger()
        {
            
        }
        public ConvertToInteger(string string1)
        {
            _string = string1;
        }

        public int ParseHelper(string userString)
        {
            try
            {
               var  sucessfullParse = ParseToInteger(userString);

                return sucessfullParse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"*******     {userString} is not an integer.     *******");
                throw new ArgumentOutOfRangeException(); ;
            }
        }
        public int ParseToInteger(string userString)
        {
            return int.Parse(userString);
        }
    }
}