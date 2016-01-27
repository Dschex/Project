using Moq;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class Calculate_UT
    {
        private MockRepository _mockRepository;
        private Mock<IGatherer> _gathererMock;
        private Calculate _testObject;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _gathererMock = _mockRepository.Create<IGatherer>();
            _testObject = new Calculate(_gathererMock.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void GetMathFunction_Calls_Gatherer_MathFunction()
        {
            string userString = "Add";

            _gathererMock.Setup(gm => gm.MathFunction(userString)).Returns("A").Verifiable();
             _testObject.GetMathFunction(userString);
        }

        [Test]
        public void GetConvertedNumber_Calls_Gatherer_ParserToInteger()
        {
            string userString = "3";
            _gathererMock.Setup(gm => gm.ParseToDouble(userString)).Returns(3).Verifiable();
            _testObject.GetConvertedNumber(userString); 
        }

        [Test]
        public void GetTotal_Calls_Gatherer_GetTotal()
        {
            string operation = "S";
            double number1 = 9.5;
            double number2 = 3.7;
            double expected = 5.8;

            _gathererMock.Setup(gm => gm.GetTotal(operation, number1, number2)).Returns(expected).Verifiable();
            _testObject.GetTotal(operation, number1, number2);

        }
    }
}
