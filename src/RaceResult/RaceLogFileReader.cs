using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace RaceResult
{
    public static class RaceLogFileReader
    {
        private static CultureInfo _formatProvider;

        static RaceLogFileReader()
        {
            _formatProvider = new CultureInfo("pt-BR");
        }

        public static IEnumerable<Lap> Read(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var result = Regex.Matches(line, @"[^\s]+");

                    yield return new Lap(
                        timeOfDay: TimeSpan.ParseExact(result[0].Value, @"hh\:mm\:ss\.fff", _formatProvider),
                        driver: new Driver(number: result[1].Value, name: result[3].Value),
                        number: int.Parse(result[4].Value, _formatProvider),
                        time: TimeSpan.ParseExact(result[5].Value, @"m\:ss\.fff", _formatProvider),
                        averageSpeed: decimal.Parse(result[6].Value, _formatProvider));
                }
            }
        }
    }
}
