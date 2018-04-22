using Gajatko.IniFiles;
using Moq;
using NUnit.Framework;

namespace OctoWatcherTests
{
    [TestFixture]
    public class IniFileElementTests
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
            IniFileElement iniFileElement = this.CreateIniFileElement("test");


            // Assert

        }

        private IniFileElement CreateIniFileElement(string a)
        {
            return new IniFileElement(a);
        }
    }
}
