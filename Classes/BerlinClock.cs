using System.Linq;

namespace BerlinClock.Classes
{
    public class BerlinClock : IClock
    {
        private const char TurnedOffLamp = 'O';
        private readonly string[] lampRows =
        {
             "Y",
             "RRRR",
             "RRRR",
             "YYRYYRYYRYY",
             "YYYY",
        };

        private static int[] GetRowsValue(Time dateTime)
        {
            var hours = dateTime.Hour;
            var minutes = dateTime.Minute;
            var seconds = dateTime.Second;

            return new[]
            {
                seconds % 2 == 1 ? 0 : 1,
                hours / 5,
                hours % 5,
                minutes / 5,
                minutes % 5,
            };
        }

        public string ConvertTime(Time dateTime)
        {
            var rowsValue = GetRowsValue(dateTime);

            var resultList = this.lampRows.Select((row, index) =>
                row.Substring(0, rowsValue[index]).PadRight(row.Length, TurnedOffLamp));

            return string.Join("\r\n", resultList);
        }
    }
}