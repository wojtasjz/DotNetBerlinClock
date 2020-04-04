using BerlinClock.Classes;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    public class BerlinClockTests
    {
        private IClock clock;

        [SetUp]
        public void Setup()
        {
            this.clock = new Classes.BerlinClock();
        }

        [Test]
        public void ReturnsCorrectString()
        {
            var expected = "O\r\nRROO\r\nRRRO\r\nYYROOOOOOOO\r\nYYOO";

            var result = this.clock.ConvertTime(new Time("13:17:51"));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
