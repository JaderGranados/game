using System;

namespace TopDown.Core
{
    /// <summary>
    /// Provides mathematical calculations related to waves of enemies in the game.
    /// </summary>
    public static class WaveMath
    {
        /// <summary>
        /// Calculates the number of enemies for a given wave based on the base number of enemies and the additional enemies added per wave.
        /// The formula used is: Total Enemies = Base Enemies + (Wave - 1) * Extra Per Wave
        /// </summary>
        /// <param name="wave">The wave number.</param>
        /// <param name="baseEnemies">The base number of enemies.</param>
        /// <param name="extraPerWave">The additional enemies added per wave.</param>
        /// <returns>The total number of enemies for the given wave.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any parameter is out of its valid range.</exception>
        /// <exception cref="OverflowException">Thrown when the calculated number of enemies exceeds the maximum value for an integer.</exception>
        public static int EnemyCount(int wave, int baseEnemies, int extraPerWave)
        {
            if (wave <= 0)
                throw new ArgumentOutOfRangeException(nameof(wave), "Wave must be greater than zero.");
            if (baseEnemies <= 0)
                throw new ArgumentOutOfRangeException(nameof(baseEnemies), "Base enemies must be greater than zero.");
            if (extraPerWave < 0)
                throw new ArgumentOutOfRangeException(nameof(extraPerWave), "Extra per wave cannot be negative.");

            return checked(baseEnemies + (wave - 1) * extraPerWave);
        }
    }
}