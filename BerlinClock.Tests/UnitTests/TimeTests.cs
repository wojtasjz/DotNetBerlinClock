using System;
using BerlinClock.Classes;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    public class TimeTests
    {
        [TestCase("invalid time")]
        [TestCase("12:12")]
        public void WhenCreatingTimeWithInvalidTimeString_ThenThrowsException(string parameter)
        {
            Action action = () => new Time(parameter);

            Assert.That(action, Throws.Exception.TypeOf<InvalidTimeException>());
        } 
        
        [Test]
        public void WhenCreatingTimeWithValidTimeString_ThenCorrectlyParsesString()
        {
            var time = new Time("13:17:02");

            Assert.That(time.Hour, Is.EqualTo(13));
            Assert.That(time.Minute, Is.EqualTo(17));
            Assert.That(time.Second, Is.EqualTo(2));
        }
    }
}
