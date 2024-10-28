using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InterviewProject.UI
{
    /// <summary>
    /// Manages the health bar UI, updating its value based on the player's health.
    /// </summary>
    public class HealthBar : MonoBehaviour, IHealthBar
    {
        [SerializeField] Slider healthBarSlider; // UI slider representing the health bar

        /// <summary>
        /// Subscribes to health change events from the specified health instance.
        /// </summary>
        /// <param name="health">The health component to subscribe to for updates.</param>
        public void SubscribeAction(IHealth health)
        {

            (health as Health).OnHealthChanged += UpdateHealthBar;
        }

        /// <summary>
        /// Updates the health bar slider based on current and maximum health values.
        /// </summary>
        /// <param name="currentHealth">The current health value of the player.</param>
        /// <param name="maxHealth">The maximum health value of the player.</param>
        private void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            healthBarSlider.value = currentHealth / maxHealth;
        }
    }
}