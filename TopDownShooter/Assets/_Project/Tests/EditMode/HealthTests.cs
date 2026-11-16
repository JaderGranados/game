using System;
using NUnit.Framework;

using TopDown.Core;

namespace TopDown.Tests
{
    public sealed class HealthTests
    {
        #region Failure Tests
        [TestCase(-10)]
        [TestCase(0)]
        public void Constructor_WithNegativeOrZeroValue_Throws(int healthValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Health(healthValue), "Health should not be initialized with a negative value or zero.");
        }

        [Test]
        public void Heal_WhenGivenNegativeValue_Throws()
        {
            var health = new Health(100);
            Assert.Throws<ArgumentOutOfRangeException>(() => health.Heal(-10), "Health should not be healed with a negative value.");
        }
        [Test]
        public void TakeDamage_WhenGivenNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            var health = new Health(100);
            Assert.Throws<ArgumentOutOfRangeException>(() => health.TakeDamage(-10), "Health should not take damage with a negative value.");
        }

        [Test]
        public void Heal_WhenIsDead_DoesNothing()
        {
            var health = new Health(100);
            health.TakeDamage(100);
            health.Heal(10);
            Assert.AreEqual(0, health.Current, "Health should not be healed when dead.");
        }

        [Test]
        public void TakeDamage_WhenIsDead_DoesNothing()
        {
            var health = new Health(100);
            health.TakeDamage(100);
            health.TakeDamage(10);
            Assert.AreEqual(0, health.Current, "Health should not take damage when dead.");
        }
        #endregion Failure Tests

        #region Success Tests
        [Test]
        public void Constructor_WithPositiveValue_InitializesCorrectly()
        {
            var health = new Health(100);
            Assert.AreEqual(100, health.Current, "Health should be initialized with the given positive value.");
        }

        [Test]
        public void Heal_WhenNotDead_Succeeds()
        {
            var health = new Health(100);
            health.TakeDamage(50);
            health.Heal(20);
            Assert.AreEqual(70, health.Current, "Health should be healed with a positive value.");
        }

        [Test]
        public void Heal_WhenDoesNotExceedMaxHealth_Succeeds()
        {
            var health = new Health(100);
            health.Heal(50);
            Assert.AreEqual(100, health.Current, "Health should not exceed max health.");
        }

        [Test]
        public void TakeDamage_WhenEqualToMaxHealth_MakesHealthDead()
        {
            var health = new Health(100);
            health.TakeDamage(100);
            Assert.IsTrue(health.IsDead, "Health should be dead after Take damage equal to max health.");
        }

        [Test]
        public void TakeDamage_WhenLessThanMaxHealth_DoesNotMakeHealthDead()
        {
            var health = new Health(100);
            health.TakeDamage(50);
            Assert.IsFalse(health.IsDead, "Health should not be dead after Take damage less than max health.");
        }
        #endregion Success Tests
    }
}
