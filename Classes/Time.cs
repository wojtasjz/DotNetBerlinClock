using System;
using System.Linq;

namespace BerlinClock.Classes
{
    public struct Time
    {
        public Time(string time)
        {
            try
            {
                var timeParts = time.Split(':').Select(int.Parse).ToArray();
                this.Hour = timeParts[0];
                this.Minute = timeParts[1];
                this.Second = timeParts[2];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new InvalidTimeException();
            }
        }

        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }
    }
}