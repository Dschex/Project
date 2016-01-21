using System;
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
            var actual = _testObject.Subtract(5, 2);
            Assert.That(actual, Is.EqualTo(3));

            actual = _testObject.Subtract(1, 2);
            Assert.That(actual, Is.EqualTo(-1));
        }
    }
}
