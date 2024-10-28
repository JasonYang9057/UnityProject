using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Defines a contract for getting player health and transformation
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Retrieves the player's health component.
        /// </summary>
        /// <returns>The IHealth interface representing the player's health.</returns>
        public IHealth GetPlayerHealth();

        /// <summary>
        /// Retrieves the player's transform component.
        /// </summary>
        /// <returns>The Transform representing the player's position, rotation, and scale.</returns>
        public Transform GetPlayerTransform();
    }
}