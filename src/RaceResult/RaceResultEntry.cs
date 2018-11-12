using System;

namespace RaceResult
{
    public class RaceResultEntry
    {
        private readonly TimeSpan _firstPlaceTotalTime;
        private readonly int _firstPlaceCompletedLaps;
        
        public int Position { get; }

        public Driver Driver { get; }

        public int CompletedLaps { get; }

        public TimeSpan TotalTime { get; }

        public decimal TotalAverageSpeed { get; }

        public TimeSpan TimeAfterFirstDriverFinishes => TotalTime - _firstPlaceTotalTime;

        public int RemainingLaps => _firstPlaceCompletedLaps - CompletedLaps;

        public RaceResultEntry(
            int position,
            Driver driver,
            int completedLaps,
            TimeSpan totalTime,
            decimal totalAverageSpeed,
            TimeSpan firstPlaceTotalTime,
            int firstPlaceCompletedLaps)
        {
            Position = position;
            Driver = driver;
            CompletedLaps = completedLaps;
            TotalTime = totalTime;
            TotalAverageSpeed = totalAverageSpeed;

            _firstPlaceTotalTime = firstPlaceTotalTime;
            _firstPlaceCompletedLaps = firstPlaceCompletedLaps;
        }
    }
}
