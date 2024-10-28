using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Interface for ranged attack behavior of enemies.
    /// </summary>
    public interface IEnemyRangedAttack
    {
        /// <summary>
        /// Initializes the ranged attack with necessary components and parameters.
        /// </summary>
        /// <param name="pool">Object pool for managing projectiles.</param>
        /// <param name="target">Target transform for the attack.</param>
        /// <param name="nameTag">Tag to identify the target.</param>
        /// <param name="damage">Damage dealt by the ranged attack.</param>
        public void Initialize(ObjectPool pool, Transform target, string nameTag, float damage);
    }
}