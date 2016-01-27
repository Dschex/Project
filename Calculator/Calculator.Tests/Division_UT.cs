using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    class Division_UT
    {
        private Division _testObject;

        [SetUp]
        public void Setup()
        {
            _testObject = new Division();
        }

        [Test]
        public void Divide_Returns_Quotient_Of_Two_Values()
        {
            double dividend = 8;
            double divisor = 4;
            double expected = 2;

            var actual = _testObject.Divide(dividend, divisor);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Divide_Throws_Exception_If_Divisor_Is_Zero()
        {
            double dividend = 8;
            double divisor = 0;

            Assert.Throws<DivideByZeroException>(() => _testObject.Divide(dividend, divisor));

        }
    }
}
