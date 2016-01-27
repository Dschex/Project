using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    class Addition_UT
    {
        private Addition _testObject;

        [SetUp]
        public void Setup()
        {
            _testObject = new Addition();
        }

        [Test]
        public void Add_Sums_Two_Values_and_Returns_A_Total()
        {
            double number1 = 1;
            double number2 = 2;
            double expected = 3;

            var actual = _testObject.Add(number1, number2);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
