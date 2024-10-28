using InterviewProject.Mechanic;
using InterviewProject.GameProgression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Manages the health and death state of an enemy, extending the base Health class.
    /// </summary>
    public class EnemyHealth : Health, IGetDeathState
    {

        /// <summary>
        /// Handles the enemy's death logic, including triggering events.
        /// </summary>
        public override void Die()
        {
            // Notify that the enemy has been killed.
            GameEvents.TriggerKillEnemy();
            // Mark the enemy as dead.
            isDead = true;
        }

        /// <summary>
        /// Returns the current death state of the enemy.
        /// </summary>
        /// <returns>True if the enemy is dead; otherwise, false.</returns>
        public bool ReturnIsDead()
        {
            return isDead;
        }
    }
}