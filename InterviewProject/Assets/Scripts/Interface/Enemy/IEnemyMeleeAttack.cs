using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Interface for melee attack behavior of enemies.
    /// </summary>
    public interface IEnemyMeleeAttack
    {
        /// <summary>
        /// Initializes the melee attack with the target and damage value.
        /// </summary>
        /// <param name="target">Target health component for the attack.</param>
        /// <param name="damage">Damage dealt by the melee attack.</param>
        public void Initialize(IHealth target, float damage);
    }
}