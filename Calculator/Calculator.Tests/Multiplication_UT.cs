using NUnit.Framework;

namespace Calculator.Tests
{
    internal class Multiplication_UT
    {
        private Multiplication _testObject;

        [SetUp]
        public void Setup()
        {
            _testObject = new Multiplication();
        }

        [Test]
        public void Multiply_Returns_Product_of_Two_Values()
        {
            double number1 = 4;
            double number2 = 5;
            double product = 20;

            var actual = _testObject.Multiply(number1, number2);

            Assert.That(actual, Is.EqualTo(product));
        }
    }
}
