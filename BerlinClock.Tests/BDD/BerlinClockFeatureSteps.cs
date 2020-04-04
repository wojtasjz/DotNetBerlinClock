using TechTalk.SpecFlow;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter berlinClock = new TimeConverter(new Classes.BerlinClock());
        private string theTime;

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            this.theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            var result = this.berlinClock.ConvertTime(this.theTime);
            Assert.AreEqual(theExpectedBerlinClockOutput, result);
        }
    }
}
