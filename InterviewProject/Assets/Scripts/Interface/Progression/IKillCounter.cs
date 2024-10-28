using InterviewProject.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.GameProgression
{
    /// <summary>
    /// Defines a contract for kill counter to initialize
    /// </summary>
    public interface IKillCounter
    {
        /// <summary>
        /// Initializes the kill counter with the specified game manager and initial amount.
        /// </summary>
        /// <param name="gameManager">The game manager to interact with.</param>
        /// <param name="amount">The initial number of kills.</param>
        public void Initialize(IGameManager gameManager, int amount);
    }
}