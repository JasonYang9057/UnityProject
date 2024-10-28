using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Mechanic
{
    /// <summary>
    /// Interface for health, defining methods for entity life and interact with attack
    /// </summary>
    public interface IHealth
    {
        /// <summary>
        /// Set maximum health of entity
        /// </summary>
        /// <param name="maxHealth">Maximum health of entity.</param>
        public void SetHealth(float maxHealth);

        /// <summary>
        /// Reduces health by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of damage taken.</param>
        public void TakeDamage(float amount);

        /// <summary>
        /// Restores health by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to heal.</param>
        public void Heal(float amount);

        /// <summary>
        /// Handles the death of the entity.
        /// </summary>
        public void Die();

        /// <summary>
        /// Revives the entity to its maximum health.
        /// </summary>
        public void Revive();
    }
}