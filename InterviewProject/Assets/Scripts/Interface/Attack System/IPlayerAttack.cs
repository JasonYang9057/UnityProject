using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.AttackSystem
{
    /// <summary>
    /// Interface for player attack components that require initialization with external dependencies.
    /// </summary>
    public interface IPlayerAttack
    {
        /// <summary>
        /// Initializes the player attack component with necessary dependencies.
        /// </summary>
        /// <param name="pool">The object pool managing attack projectiles.</param>
        /// <param name="nameTag">The tag of the target for the attack.</param>
        /// <param name="damage">The damage value per attack.</param>
        /// <param name="attackSpeed">The speed at which attacks occur.</param>
        public void Initialize(ObjectPool pool, string nameTag, float damgae, float attackSpeed);
    }
}