using System;
using NUnit.Framework;
using TopDown.Core;

namespace TopDown.Tests
{
    public sealed class WaveMathTests
    {
        #region Failure Cases
        [TestCase(0, 1, 2)]
        [TestCase(-1, 1, 2)]
        public void EnemyCount_WaveZeroOrNegative_Throws(int wave, int baseEnemies, int extraPerWave)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WaveMath.EnemyCount(wave, baseEnemies, extraPerWave), "Expected ArgumentOutOfRangeException when wave is zero or negative.");
        }

        [TestCase(1, 0, 2)]
        [TestCase(1, -1, 2)]
        public void EnemyCount_BaseEnemiesZeroOrNegative_Throws(int wave, int baseEnemies, int extraPerWave)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WaveMath.EnemyCount(wave, baseEnemies, extraPerWave), "Expected ArgumentOutOfRangeException when baseEnemies is zero or negative.");
        }

        [Test]
        public void EnemyCount_ExtraPerWaveNegative_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WaveMath.EnemyCount(1, 1, -1), "Expected ArgumentOutOfRangeException when extraPerWave is negative.");
        }

        [Test]
        public void EnemyCount_Overflow_Throws()
        {
            Assert.Throws<OverflowException>(() => WaveMath.EnemyCount(int.MaxValue, int.MaxValue, int.MaxValue), "Expected OverflowException when calculation exceeds int.MaxValue.");
        }
        #endregion Failure Cases

        #region Success Cases
        [TestCase(1, 5, 2, 5)]
        [TestCase(2, 5, 2, 7)]
        [TestCase(3, 5, 2, 9)]
        [TestCase(4, 5, 2, 11)]
        [TestCase(5, 5, 2, 13)]
        [TestCase(1, 10, 0, 10)]
        [TestCase(2, 10, 0, 10)]
        [TestCase(3, 10, 0, 10)]
        [TestCase(1, 3, 1, 3)]
        [TestCase(2, 3, 1, 4)]
        [TestCase(3, 3, 1, 5)]
        public void EnemyCount_ShouldReturnCorrectEnemyCount(int wave, int baseEnemies, int extraPerWave, int expectedCount)
        {
            var result = WaveMath.EnemyCount(wave, baseEnemies, extraPerWave);
            Assert.That(result, Is.EqualTo(expectedCount));
        }
        #endregion Success Cases
    }
}