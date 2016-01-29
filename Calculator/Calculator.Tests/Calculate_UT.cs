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
    }
}
