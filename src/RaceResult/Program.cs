using System;
using System.IO;

namespace RaceResult
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || !File.Exists(args[0]))
                throw new ArgumentException();

            var race = new Race(RaceLogFileReader.Read(args[0]));

            Console.WriteLine("RACE RESULTS");
            Console.WriteLine("POS | NO | DRIVER | LAPS | TIME | AVG SPEED");
            foreach (var e in race.Result())
                Console.WriteLine($"{e.Position} | {e.Driver.Number} | {e.Driver.Name} | " +
                    $"{e.CompletedLaps} | {e.TotalTime.ToString(@"m\:ss\.fff")} | " +
                    $"{e.TotalAverageSpeed.ToString("0.000")}");

            Console.WriteLine();

            Console.WriteLine("FASTEST LAPS");
            Console.WriteLine("POS | NO | DRIVER | LAP | TIME OF DAY | TIME | AVG SPEED");
            foreach (var e in race.FastestLaps())
                Console.WriteLine($"{e.Position} | {e.Driver.Number} | {e.Driver.Name} | " +
                    $"{e.Number} | {e.TimeOfDay.ToString(@"hh\:mm\:ss\.fff")} | " +
                    $"{e.Time.ToString(@"m\:ss\.fff")} | {e.AverageSpeed}");

            Console.WriteLine();

            Console.WriteLine("FASTEST LAP");
            Console.WriteLine("POS | NO | DRIVER | LAP | TIME OF DAY | TIME | AVG SPEED");
            var f = race.FastestLap();
                Console.WriteLine($"{f.Position} | {f.Driver.Number} | {f.Driver.Name} | " +
                    $"{f.Number} | {f.TimeOfDay.ToString(@"hh\:mm\:ss\.fff")} | " +
                    $"{f.Time.ToString(@"m\:ss\.fff")} | {f.AverageSpeed}");
        }
    }
}
