using Moq;
using NUnit.Framework;
using OctoWatcher;

namespace OctoWatcherTests
{
    [TestFixture]
    public class MainFormTests
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
            MainForm mainForm = this.CreateMainForm();


            // Assert

        }

        private MainForm CreateMainForm()
        {
            return new MainForm();
        }
    }
}
