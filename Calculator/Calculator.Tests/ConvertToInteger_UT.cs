using System;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Tests
{
    [TestFixture]
    public class ConvertToInteger_UT
    {
        Mock<IConvertToInteger> _IConvertToInteger;
        public ConvertToInteger _testObject;
            
        [TestFixtureSetUp]
        public void Setup()
        {
            _IConvertToInteger = new Mock<IConvertToInteger>().SetupAllProperties();
            _testObject = new ConvertToInteger();
        }

        [Test]
        public void StringToInteger_Returns_Integer_For_Supplied_String()
        {
            /*Should this test only verify that ParseToInteger is called in the Try block*/
            string userString = "5";
            int expected = 5;

            var actual = _testObject.ParseHelper(userString);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void StringToInteger_Throws_Exception_When_User_String_Is_Empty_Or_NonInteger()
        {
            string userString1 = "a";
            string userString2 = string.Empty;
 
            Assert.Catch<ArgumentOutOfRangeException>(() => _testObject.ParseHelper(userString1));
            Assert.Catch<ArgumentOutOfRangeException>(() => _testObject.ParseHelper(userString2));
        }

        [Test]
        public void ParseToInteger_Returns_Integer_When_ParseToInt_Is_Possible()
        {
            string userString = "5";
            int expectedResult = 5;

            Assert.That(_testObject.ParseToInteger(userString), Is.EqualTo(expectedResult));
        }

        [Test]
        public void ParseToInteger_Returns_Exception_When_Unable_To_Parse_To_Int()
        {
            string userString1 = "a";
            string userString2 = string.Empty;

            Assert.Throws<ArgumentOutOfRangeException>(() => _testObject.ParseHelper(userString1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _testObject.ParseHelper(userString2));
        }
    }
}
