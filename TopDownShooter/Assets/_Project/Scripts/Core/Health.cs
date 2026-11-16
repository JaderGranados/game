using System;

namespace TopDown.Core
{
    /// <summary>
    /// Represents the health of an entity in the game.
    /// </summary>
    public sealed class Health
    {
        public int MaxHealth { get; }
        public int Current { get; private set; }
        public bool IsDead => Current <= 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Health"/> class with the specified maximum health.
        /// The current health is set to the maximum health upon initialization.
        /// </summary>
        /// <param name="maxHealth">The maximum health for the entity.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when maxHealth is negative or zero.</exception>
        public Health(int maxHealth)
        {
            if (maxHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxHealth), "Health should not be initialized with a negative value or zero.");
            }

            MaxHealth = maxHealth;
            Current = maxHealth;
        }

        /// <summary>
        /// Takes damage from an attack.
        /// </summary>
        /// <param name="damage">The amount of damage to take.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when damage is negative.</exception>
        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage should not be negative.");
            if (IsDead)
                return;

            Current = Math.Max(Current - damage, 0);
        }

        /// <summary>
        /// Heals the entity by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of health to restore.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount is negative.</exception>
        public void Heal(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Health should not be healed with a negative value.");
            if (IsDead)
                return;

            Current = Math.Min(Current + amount, MaxHealth);
        }
    }
}