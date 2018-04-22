using System.IO;
using Moq;
using NUnit.Framework;
using Temp.IO;

namespace OctoWatcherTests
{
    [TestFixture]
    public class MyFileSystemWatcherTests
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
            MyFileSystemWatcher myFileSystemWatcher = this.CreateMyFileSystemWatcher();
            myFileSystemWatcher = this.CreateMyFileSystemWatcher(Directory.GetCurrentDirectory());
            myFileSystemWatcher = this.CreateMyFileSystemWatcher(Directory.GetCurrentDirectory(), "*.txt");

            // Assert

        }

        private MyFileSystemWatcher CreateMyFileSystemWatcher()
        {
            return new MyFileSystemWatcher();
        }

        private MyFileSystemWatcher CreateMyFileSystemWatcher(string a)
        {
            return new MyFileSystemWatcher(a);
        }

        private MyFileSystemWatcher CreateMyFileSystemWatcher(string a, string b)
        {
            return new MyFileSystemWatcher(a, b);
        }
    }
}
