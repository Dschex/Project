using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class Subtraction_UT
    {
        private Subtraction _testObject;

        [SetUp]
        public void Setup()
        {
            _testObject = new Subtraction();
        }

        [Test]
        public void Subtract_Gives_Difference_Between_Two_Values_and_Returns_A_Total()
        {
            double number1 = 5;
            double number2 = 2;
            double expected1 = 3;
            double number3 = 1;
            double number4 = 2;
            double expected2 = -1;

            var actual = _testObject.Subtract(number1, number2);
            Assert.That(actual, Is.EqualTo(expected1));

            actual = _testObject.Subtract(1, 2);
            Assert.That(actual, Is.EqualTo(-1));
        }
    }
}
