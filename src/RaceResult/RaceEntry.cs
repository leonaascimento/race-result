using System;
using System.Collections.Generic;

namespace RaceResult
{
    public class RaceEntry
    {
        public Driver Driver { get; }

        public int CompletedLaps { get; }

        public TimeSpan TotalTime { get; }

        public decimal TotalAverageSpeed { get; }

        public Lap FastestLap { get; }

        public RaceEntry(Driver driver, IEnumerable<Lap> laps)
        {
            Driver = driver;
            CompletedLaps = laps.CompletedLaps();
            TotalTime = laps.TotalTime();
            TotalAverageSpeed = laps.TotalAverageSpeed();
            FastestLap = laps.FastestLap();
        }
    }
}
