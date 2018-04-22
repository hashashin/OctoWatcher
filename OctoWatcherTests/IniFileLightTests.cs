using Gajatko.IniFiles.Light;
using Moq;
using NUnit.Framework;

namespace OctoWatcherTests
{
    [TestFixture]
    public class IniFileLightTests
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
            IniFileLight iniFileLight = this.CreateIniFileLight();


            // Assert

        }

        private IniFileLight CreateIniFileLight()
        {
            return new IniFileLight();
        }
    }
}
