using System;

namespace RaceResult
{
    public class Lap
    {
        public Driver Driver { get; }

        public TimeSpan TimeOfDay { get; }

        public int Number { get; }

        public TimeSpan Time { get; }

        public decimal AverageSpeed { get; }

        public Lap(
            Driver driver,
            TimeSpan timeOfDay,
            int number,
            TimeSpan time,
            decimal averageSpeed)
        {
            Driver = driver;
            TimeOfDay = timeOfDay;
            Number = number;
            Time = time;
            AverageSpeed = averageSpeed;
        }
    }
}
