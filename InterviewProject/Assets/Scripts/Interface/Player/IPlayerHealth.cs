using InterviewProject.Attribute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Defines a contract for player health to initialize
    /// </summary>
    public interface IPlayerHealth
    {
        /// <summary>
        /// Initializes the player health component with the specified player attributes.
        /// </summary>
        /// <param name="playerAttributes">The attributes to be used for initializing player health.</param>
        public void Initialize(IPlayerAttributes playerAttributes);
    }
}