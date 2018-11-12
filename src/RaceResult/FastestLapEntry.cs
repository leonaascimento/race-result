using System;

namespace RaceResult
{
    public class FastestLapEntry
    {
        public int Position { get; }

        public Driver Driver { get; }

        public TimeSpan TimeOfDay { get; }

        public int Number { get; }

        public TimeSpan Time { get; }

        public decimal AverageSpeed { get; }

        public FastestLapEntry(
            int position,
            Driver driver,
            TimeSpan timeOfDay,
            int number,
            TimeSpan time,
            decimal averageSpeed)
        {
            Position = position;
            Driver = driver;
            TimeOfDay = timeOfDay;
            Number = number;
            Time = time;
            AverageSpeed = averageSpeed;
        }
    }
}
