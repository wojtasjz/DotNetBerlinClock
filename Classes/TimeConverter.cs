using System;

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
            Time time;
            try
            {
                time = new Time(aTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new InvalidTimeException();
            }

            return this.clock.ConvertTime(time);
        }
    }
}
