using NUnit.Framework;
using Terra.Net.Lcd.Interfaces;

namespace Terra.Net.Lcd.Tests
{
    public class LcdNodeIntegrationTests
    {
        private readonly ITerraLcdClient _lcd;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}