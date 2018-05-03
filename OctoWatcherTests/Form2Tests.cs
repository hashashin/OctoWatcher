using Moq;
using NUnit.Framework;
using OctoWatcher;

namespace OctoWatcherTests
{
    [TestFixture]
    public class Form2Tests
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
            Form2 form2 = this.CreateForm2();


            // Assert

        }

        private Form2 CreateForm2()
        {
            return new Form2();
        }
    }
}
