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
        private Mock<IDivision> _divisionMock; 
        private Gatherer _testObject;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _additionMock = _mockRepository.Create<IAddition>();
            _subtractMock = _mockRepository.Create<ISubtraction>();
            _multiplicationMock = _mockRepository.Create<IMultiplication>();
            _divisionMock = _mockRepository.Create<IDivision>();
            _testObject = new Gatherer(_additionMock.Object, _subtractMock.Object, _multiplicationMock.Object, _divisionMock.Object);
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
        public void MathFunction_Should_Return_Division_When_Divide_Function_Is_Selected_()
        {
            string userString1 = "D";
            string userString2 = "d";
            string userString3 = "DIVIDE";
            string userString4 = "divide";
            string expected = "D";

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
        public void ParseToDouble_Returns_A_Double_When_Parse_Is_Possible()
        {
            string userString1 = "5";
            double expectedResult1 = 5;
            Assert.That(_testObject.ParseToDouble(userString1), Is.EqualTo(expectedResult1));

            string userString2 = "5.6989897989";
            double expectedResult2 = 5.6989897989;
            Assert.That(_testObject.ParseToDouble(userString2), Is.EqualTo(expectedResult2));
                
            string userString3 = "-2147483648.0";
            double expectedResult3= int.MinValue;
            Assert.That(_testObject.ParseToDouble(userString3), Is.EqualTo(expectedResult3));
        }

        [Test]
        public void ParseToDouble_Returns_Exception_When_Unable_To_Parse()
        {
            string userString1 = "a";
            Assert.Throws<FormatException>(() => _testObject.ParseToDouble(userString1));

            string userString2 = string.Empty;
            Assert.Throws<FormatException>(() => _testObject.ParseToDouble(userString2));
        
            string userString3 = "-1.7976931348623157E+308";
            Assert.Throws<FormatException>(() => _testObject.ParseToDouble(userString3));

            string userString4 = "1.7976931348623157E+308";
            Assert.Throws<FormatException>(() => _testObject.ParseToDouble(userString4));

            string userString5 = "-1.7976931348623157E+309";
            Assert.Throws<OverflowException>(() => _testObject.ParseToDouble(userString5));

            string userString6 = "1.7976931348623157E+309";
            Assert.Throws<OverflowException>(() => _testObject.ParseToDouble(userString6));
        }

        [Test]
        public void ParseToDouble_Returns_Exception_When_UserString_Parses_To_MinValue_Or_MaxValue()
        {
            string userString1 = "1.7976931348623157E+308";
            Assert.Throws<FormatException>(()=> _testObject.ParseToDouble(userString1));

            string userString2 = "-1.7976931348623157E+308";
            Assert.Throws<FormatException>(()=> _testObject.ParseToDouble(userString2));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Addition()
        {
            string operation1 = "A";
            double number1 = 8;
            double number2 = 3;
            double total = 11;
            string expected = $"The sum of {number1} + {number2} is {total}";

            _additionMock.Setup(am => am.Add(number1, number2)).Returns(total).Verifiable();
            var actual = _testObject.GetTotal(operation1, number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Subtraction()
        {
            string operation = "S";
            double number1 = 8;
            double number2 = 3;
            double total = 5;
            string expected = $"The difference of {number1} - {number2} is {total}";

            _subtractMock.Setup(sm => sm.Subtract(number1, number2)).Returns(total).Verifiable();
            var actual = _testObject.GetTotal(operation, number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Multiplication()
        {
            string operation = "M";
            double number1 = 4;
            double number2 = 5;
            double total = 20;
            string expected = $"The product of {number1} * {number2} is {total}";

            _multiplicationMock.Setup(mm => mm.Multiply(number1, number2)).Returns(total).Verifiable();
            var actual = _testObject.GetTotal(operation, number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTotal_Correctly_Picks_Division()
        {
            string operation = "D";
            double number1 = 90;
            double number2 = 15;
            double total = 6;
            string expected = $"The quotient of { number1} / { number2} is { total}";

            _divisionMock.Setup(dm => dm.Divide(number1, number2)).Returns(total).Verifiable();
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