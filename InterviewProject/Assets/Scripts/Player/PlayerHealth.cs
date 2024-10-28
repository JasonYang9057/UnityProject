using InterviewProject.Attribute;
using InterviewProject.Mechanic;
using InterviewProject.GameProgression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the player's health, including regeneration and death events.
/// </summary>
namespace InterviewProject.ThePlayer
{
    public class PlayerHealth : Health, IPlayerHealth
    {
        private float regenerationTime; // Time interval for health regeneration.
        private float regenerationAmount; // Amount of health to regenerate.

        private float currTime = 0f; // Tracks the current time for regeneration.
        public UnityEvent OnPlayerDeath; // Event triggered when the player dies.

        /// <summary>
        /// Initializes the player health parameters based on player attributes.
        /// </summary>
        /// <param name="playerAttributes">The attributes used to set regeneration values.</param>
        public void Initialize(IPlayerAttributes playerAttributes)
        {
            regenerationTime = playerAttributes.RegenerationTime;
            regenerationAmount = playerAttributes.RegeneraitonAmount;
        }

        void Update()
        {
            if (!isDead)
            {
                HealOverTime();
            }
        }

        /// <summary>
        /// Regenerates health over time based on the defined regeneration parameters.
        /// </summary>
        private void HealOverTime()
        {
            currTime += Time.deltaTime;
            if (currTime > regenerationTime)
            {
                currTime = 0f;
                Heal(regenerationAmount);
            }
        }

        /// <summary>
        /// Handles the player's death by setting the dead state and triggering events.
        /// </summary>
        public override void Die()
        {
            isDead = true;
            OnPlayerDeath?.Invoke();
            // Trigger game over events.
            GameEvents.TriggerGameOver();
        }
    }
}