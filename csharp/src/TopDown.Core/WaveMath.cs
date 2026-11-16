using System;

namespace TopDown.Core
{
    /// <summary>
    /// Provides mathematical calculations related to waves in a game, 
    ///     such as determining the number of enemies based on the wave number, base enemies, and extra enemies per wave.
    /// </summary>
    public static class WaveMath
    {
        /// <summary>
        /// Calculates the number of enemies for a given wave based on the base number of enemies and the extra enemies added per wave.
        /// </summary>
        /// <param name="wave">Wave number</param>
        /// <param name="baseEnemies">Base number of enemies</param>
        /// <param name="extraPerWave">Extra enemies added per wave</param>
        /// <returns>Number of enemies for the specified wave</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the wave number or enemy counts are invalid</exception>
        /// <exception cref="OverflowException">Thrown when the calculated number of enemies exceeds the maximum value for an integer</exception>
        public static int EnemyCount(int wave, int baseEnemies, int extraPerWave)
        {
            if (wave <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wave), "Wave must be greater than 0");
            }
            if (baseEnemies < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(baseEnemies), "Base enemies must be non-negative");
            }
            if (extraPerWave < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(extraPerWave), "Extra per wave must be non-negative");
            }

            return checked(baseEnemies + ((wave - 1) * extraPerWave));
        }
    }
}