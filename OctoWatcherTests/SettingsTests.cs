using Moq;
using NUnit.Framework;
using OctoWatcher.Properties;

namespace OctoWatcherTests
{
    [TestFixture]
    public class SettingsTests
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
            Settings settings = this.CreateSettings();


            // Assert

        }

        private Settings CreateSettings()
        {
            return new Settings();
        }
    }
}
