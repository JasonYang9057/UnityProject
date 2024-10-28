using InterviewProject.Mechanic;
using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Interface for enemy behavior, allowing initialization with necessary components.
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// Initializes the enemy with an object pool, health component, and transform.
        /// </summary>
        /// <param name="pool">Object pool for managing enemy instances.</param>
        /// <param name="health">Health component for the enemy.</param>
        /// <param name="trans">Transform of the enemy.</param>
        public void Initialize(ObjectPool pool, IHealth health, Transform trans);
    }
}