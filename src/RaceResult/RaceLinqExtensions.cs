using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceResult
{
    public static class RaceLinqExtensions
    {
        public static int CompletedLaps(this IEnumerable<Lap> laps)
        {
            return laps.Count();
        }

        public static Lap FastestLap(this IEnumerable<Lap> laps)
        {
            return laps.OrderBy(lap => lap.Time).First();
        }

        public static decimal TotalAverageSpeed(this IEnumerable<Lap> laps)
        {
            return laps.Count() / laps.Sum(lap => 1.0m / lap.AverageSpeed);
        }

        public static TimeSpan TotalTime(this IEnumerable<Lap> laps)
        {
            return new TimeSpan(laps.Sum(lap => lap.Time.Ticks));
        }
    }
}
