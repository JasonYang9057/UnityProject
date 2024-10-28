using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Manager
{
    /// <summary>
    /// Defines a contract for enemy manager to initialize and return enemy count
    /// </summary>
    public interface IEnemyManager
    {
        /// <summary>
        /// Initializes the enemy manager with player references.
        /// </summary>
        /// <param name="playerHealth">The health of the player.</param>
        /// <param name="playerTrans">The transform of the player.</param>
        public void Initialize(IHealth playerHealth, Transform playerTrans);

        /// <summary>
        /// Returns the current count of enemies.
        /// </summary>
        /// <returns>The number of active enemies.</returns>
        public int GetEnemyCount();
    }
}