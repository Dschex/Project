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
        public void Adds_Sums_Two_Values_and_Returns_A_Total()
        {
            var actual = _testObject.Add(1, 2);

            Assert.That(actual, Is.EqualTo(3));
        }
    }
}
