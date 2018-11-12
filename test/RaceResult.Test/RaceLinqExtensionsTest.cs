using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RaceResult.Test
{
    [TestFixture]
    class RaceLinqExtensionsTest
    {
        private List<Lap> _driverLaps;

        [SetUp]
        public void Init()
        {
            _driverLaps = new List<Lap>()
            {
                new Lap(new Driver("0", "JOHN"), TimeSpan.FromSeconds(60), 1, TimeSpan.FromSeconds(60), 100m),
                new Lap(new Driver("0", "JOHN"), TimeSpan.FromSeconds(108), 2, TimeSpan.FromSeconds(48), 80m),
            };
        }

        [Test]
        public void TestCompletedLaps()
        {
            // Act
            var result = _driverLaps.CompletedLaps();

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void TestTotalAverageSpeed()
        {
            // Act
            var result = _driverLaps.TotalAverageSpeed();

            // Assert
            Assert.That(result, Is.EqualTo(88.889m).Within(0.001m));
        }

        [Test]
        public void TestTotalTime()
        {
            // Act
            var result = _driverLaps.TotalTime();

            // Assert
            Assert.That(result, Is.EqualTo(TimeSpan.FromSeconds(108)));
        }
    }
}
