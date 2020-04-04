namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IClock clock;

        public TimeConverter(IClock clock)
        {
            this.clock = clock;
        }

        public string ConvertTime(string aTime)
        {
            var time = new Time(aTime);

            return this.clock.ConvertTime(time);
        }
    }
}
