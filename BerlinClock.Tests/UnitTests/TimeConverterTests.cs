using System;
using BerlinClock.Classes;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    public class TimeConverterTests
    {
        private ITimeConverter timeConverter;
        private Mock<IClock> clockMock;

        [SetUp]
        public void Setup()
        {
            this.clockMock = new Mock<IClock>();
            this.timeConverter = new TimeConverter(this.clockMock.Object);
        }

        [Test]
        public void WhenPassingInvalidTimeString_ThenThrowsInvalidTimeException()
        {
            Action action = () => this.timeConverter.ConvertTime("invalidTime");

            Assert.That(action, Throws.Exception.TypeOf<InvalidTimeException>());
        }

        [Test]
        public void WhenPassingValidTimeString_ThenCorrectlyParsesStringAndCallsClock()
        {
            this.timeConverter.ConvertTime("12:15:34");

            this.clockMock.Verify(clock => clock.ConvertTime(It.Is<Time>(time => time.Hour == 12 && time.Minute == 15 && time.Second == 34)), Times.Once);
        } 

        [Test]
        public void WhenPassingValidTimeString_ThenReturnsConvertedTime()
        {
            const string convertedTime = "CONVERTED";
            this.clockMock.Setup(clock => clock.ConvertTime(It.IsAny<Time>())).Returns(convertedTime);

            var result = this.timeConverter.ConvertTime("12:15:34");

            Assert.That(result, Is.EqualTo(convertedTime));
        }
    }
}
