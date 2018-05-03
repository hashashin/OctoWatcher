using Moq;
using NUnit.Framework;
using OctoWatcher;

namespace OctoWatcherTests
{
    [TestFixture]
    public class cPrinterProfilesTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void TestMethod1()
        {
            // Arrange


            // Act
            cPrinterProfiles cPrinterProfiles = this.CreatecPrinterProfiles();


            // Assert

        }

        private cPrinterProfiles CreatecPrinterProfiles()
        {
            return new cPrinterProfiles();
        }
    }
}
