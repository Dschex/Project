using System;
using System.Runtime.Remoting.Messaging;
using Moq;
using NUnit.Framework;
using Xunit;
using Xunit.Sdk;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Tests
{
    [TestFixture]
    public class Calculate_UT
    {
        private MockRepository _mockRepository;
        private Mock<IGatherer> _gathererMock;
        private Mock<IAddition> _additionMock;
        private Mock<ISubtraction> _subtractMock; 
        private Calculate _testObject;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict); 

            _gathererMock = _mockRepository.Create<IGatherer>();
            _additionMock = _mockRepository.Create<IAddition>();
            _subtractMock = _mockRepository.Create<ISubtraction>();
            _testObject = new Calculate(_gathererMock.Object, _additionMock.Object, _subtractMock.Object);
        }

        [TearDown]
        private void Teardown()
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
        public void CallGatherer_Should_Make_Call_To_Gatherer()
        {
            string userInput1 = "2";

            _gathererMock.Setup(gm => gm.GatherInteger(userInput1)).Returns(2).Verifiable();
            _testObject.CallGatherer(userInput1);
        }

        [Test]
        public void CallGatherer_Should_Make_Call_To_Gatherer2()
        {
           // var catchMessage = ($"I am restarting the program.\r\nWould you like to ADD or SUBTRACT ? \r\nType A to Add, and S to Substract");
            string userInput1 = "r";

            _gathererMock.Setup(gm => gm.GatherInteger(userInput1)).Throws<ArgumentOutOfRangeException>().ToString();
            _testObject.CallGatherer(userInput1);
            
           // Assert.That(_gathererMock.Object.GatherInteger(userInput1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
