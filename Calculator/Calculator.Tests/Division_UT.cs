using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    class Division_UT
    {
        private Divison _testObject;

        [SetUp]
        public void Setup()
        {
            _testObject = new Divison();
        }

        [Test]
        public void Divide_Returns_Quotient_Of_Two_Values()
        {
            int dividend = 8;
            int divisor = 4;
            int expected = 2;

            var actual = _testObject.Divide(dividend, divisor);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Divide_Returns_Message_If_Divisor_Is_Zero()
        {
            int dividend = 8;
            int divisor = 0;

            Assert.Throws<DivideByZeroException>(() => _testObject.Divide(dividend, divisor));

        }
    }
}
