using System;
using Moq;
using NUnit.Framework;
using Xunit.Sdk;

namespace Calculator.Tests
{
    [TestFixture]
    public class Calculate_UT
    {
        Mock<Calculate> _calculateMock;
        Mock<IGatherer> _gathererMock;
        Mock<IAddition> _additionMock;
        Mock<ISubtraction> _subtractMock; 
        public Calculate _testObject;

        [SetUp]
        public void Setup()
        {
            _gathererMock = new Mock<IGatherer>(MockBehavior.Strict).SetupAllProperties();
            _additionMock = new Mock<IAddition>(MockBehavior.Strict).SetupAllProperties();
            _subtractMock = new Mock<ISubtraction>(MockBehavior.Strict).SetupAllProperties();
            //_calculateMock = new Mock<Calculate>().Run().ToString();
            _testObject = new Calculate();
        }

        [Test]
        public void Run_Should_Call_Addition_When_Selected()
        {
            string _userInput = "A";
            int convertedInteger1 = 4;
            int convertedInteger2 = 9;

            _additionMock.When(_testObject.Run(_userInput));

            _gathererMock.Verify(_testObject => _testObject.GatherInteger(_userInput));
            //(convertedInteger1, convertedInteger2));

        }
    }
}
