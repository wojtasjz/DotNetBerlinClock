using System.Linq;

namespace BerlinClock.Classes
{
    public struct Time
    {
        public Time(string time)
        {
            var timeParts = time.Split(':').Select(int.Parse).ToArray();
            this.Hour = timeParts[0];
            this.Minute = timeParts[1];
            this.Second = timeParts[2];
        }

        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }
    }
}