using System.Collections.Generic;
using System.Linq;

namespace RaceResult
{
    public class Race
    {
        private readonly IEnumerable<RaceEntry> _raceEntries;

        public Race(IEnumerable<Lap> laps)
        {
            _raceEntries =
                laps.GroupBy(lap => lap.Driver)
                    .Select(driverLaps => new RaceEntry(driver: driverLaps.Key, laps: driverLaps));
        }

        public IEnumerable<RaceResultEntry> Result()
        {
            var ordered = _raceEntries
                .OrderByDescending(e => e.CompletedLaps)
                .ThenBy(e => e.TotalTime);

            var firstPlace = ordered.First();

            return ordered.Select((e, position) => new RaceResultEntry(
                position: position + 1,
                driver: e.Driver,
                completedLaps: e.CompletedLaps,
                totalTime: e.TotalTime,
                totalAverageSpeed: e.TotalAverageSpeed,
                firstPlaceTotalTime: firstPlace.TotalTime,
                firstPlaceCompletedLaps: firstPlace.CompletedLaps));
        }

        public IEnumerable<FastestLapEntry> FastestLaps()
        {
            return _raceEntries
                .OrderBy(e => e.FastestLap.Time)
                .ThenBy(e => e.TotalTime)
                .Select((e, position) => new FastestLapEntry(
                    position: position + 1,
                    driver: e.Driver,
                    timeOfDay: e.FastestLap.TimeOfDay,
                    number: e.FastestLap.Number,
                    time: e.FastestLap.Time,
                    averageSpeed: e.FastestLap.AverageSpeed));
        }

        public FastestLapEntry FastestLap()
        {
            return FastestLaps().First();
        }
    }
}
