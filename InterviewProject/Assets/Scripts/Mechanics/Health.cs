using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InterviewProject.Mechanic
{
    /// <summary>
    /// Abstract class that manages health for game entities, allowing for damage, healing, and death behavior.
    /// </summary>
    public abstract class Health : MonoBehaviour, IHealth
    {
        protected float maxHealth; // Maximum health of the entity.
        protected float currentHealth; // Current health of the entity.
        protected bool isDead = false; // Indicates if the entity is dead.

        public event Action<float, float> OnHealthChanged; // Event triggered on health change.
        public UnityEvent OnHurt; // Event triggered when the entity takes damage.

        /// <summary>
        /// Sets the maximum health and initializes current health.
        /// </summary>
        /// <param name="maxHealth">Maximum health value.</param>
        public virtual void SetHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }

        /// <summary>
        /// Applies damage to the entity.
        /// </summary>
        /// <param name="amount">Damage amount.</param>
        public virtual void TakeDamage(float amount)
        {
            // Stop method if entity is already dead
            if (isDead) return;

            currentHealth -= amount;
            // Trigger hurt event
            OnHurt?.Invoke();
            // Trigger health changed event
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
            
            // Set state to dead if lose all health
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }

        /// <summary>
        /// Heals the entity by a specified amount.
        /// </summary>
        /// <param name="amount">Healing amount.</param>
        public virtual void Heal(float amount)
        {
            // Stop method if entity is already dead
            if (isDead) return;

            // Increase health
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            // Trigger health changed event
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        /// <summary>
        /// Defines behavior when the entity dies.
        /// </summary>
        public abstract void Die();

        /// <summary>
        /// Revives the entity and restores health to maximum.
        /// </summary>
        public virtual void Revive()
        {
            isDead = false;
            Heal(maxHealth);
        }

        /// <summary>
        /// Cleans up event subscriptions on destroy.
        /// </summary>
        private void OnDestroy()
        {
            OnHealthChanged = null;
        }
    }
}