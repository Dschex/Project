using System;
using Moq;
using NUnit.Framework;

namespace Calculator.Tests
{
    internal class Gatherer_UT
    {
        private MockRepository _mockRepository;
        private Mock<IAddition> _additionMock;
        private Mock<ISubtraction> _subtractMock;
        private Mock<IMultiplication> _multiplicationMock; 
        private Gatherer _testObject;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _additionMock = _mockRepository.Create<IAddition>();
            _subtractMock = _mockRepository.Create<ISubtraction>();
            _multiplicationMock = _mockRepository.Create<IMultiplication>();
            _testObject = new Gatherer(_additionMock.Object, _subtractMock.Object, _multiplicationMock.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void MathFunction_Should_Return_Addition_When_Add_Function_Is_Selected_()
        {
            string userString1 = "A";
            string userString2 = "a";
            string userString3 = "ADD";
            string userString4 = "add";
            string expected = "A";

            var actual = _testObject.MathFunction(userString1);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString2);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString3);
            Assert.That(actual, Is.SameAs(expected));

             actual = _testObject.MathFunction(userString4);
            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void MathFunction_Should_Return_Subtraction_When_Subtract_Function_Is_Selected_()
        {
            string userString1 = "S";
            string userString2 = "s";
            string userString3 = "SUBTRACT";
            string userString4 = "subtract";
            string expected = "S";

            var actual = _testObject.MathFunction(userString1);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString2);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString3);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString4);
            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void MathFunction_Should_Return_Multiplication_When_Multiply_Function_Is_Selected_()
        {
            string userString1 = "M";
            string userString2 = "m";
            string userString3 = "MULTIPLY";
            string userString4 = "multiply";
            string expected = "M";

            var actual = _testObject.MathFunction(userString1);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString2);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString3);
            Assert.That(actual, Is.SameAs(expected));

            actual = _testObject.MathFunction(userString4);
            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void MathFunction_Should_Return_Exception_If_User_Selection_Is_Invalid_()
        {
            string userString = "b";

            Assert.Throws<ArgumentOutOfRangeException>(()=> _testObject.MathFunction(userString));
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
            string userString3 = "0.58968";

            Assert.Throws<FormatException>(() => _testObject.ParseToInteger(userString1));
            Assert.Throws<FormatException>(() => _testObject.ParseToInteger(userString2));
            Assert.Throws<FormatException>(() => _testObject.ParseToInteger(userString3));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Addition()
        {
            string operation1 = "A";
            int number1 = 8;
            int number2 = 3;
            int expected = 11;

            var actual = _testObject.GetTotal(operation1, number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Subtraction()
        {
            string operation = "S";
            int number1 = 8;
            int number2 = 3;
            int expected = 5;

            var actual = _testObject.GetTotal(operation, number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Multiplication()
        {
            string operation = "M";
            int number1 = 4;
            int number2 = 5;
            int expected = 20;

            var actual = _testObject.GetTotal(operation, number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTotal_Throws_Exception_When_Math_Operation_Is_Invalid()
        {
            string operation = "nothing";
            int number1 = 8;
            int number2 = 3;

            Assert.Throws<ArgumentOutOfRangeException>(()=> _testObject.GetTotal(operation, number1, number2));
        }
    }
}