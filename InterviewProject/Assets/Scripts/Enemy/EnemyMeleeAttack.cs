using InterviewProject.AttackSystem;
using InterviewProject.Mechanic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Handles melee attack behavior for enemies, extending BasicAttack.
    /// </summary>
    public class EnemyMeleeAttack : BasicAttack, IEnemyMeleeAttack
    {
        private IHealth playerHealth; // Reference to the player's health component.
        private float attackDamage; // Damage dealt by the melee attack.

        /// <summary>
        /// Executes the melee attack, dealing damage to the player.
        /// </summary>
        public override void Attack()
        {
            // Apply damage to the player.
            playerHealth.TakeDamage(attackDamage);
        }

        /// <summary>
        /// Initializes the melee attack with target health and damage value.
        /// </summary>
        /// <param name="target">Target health component for the attack.</param>
        /// <param name="damage">Damage dealt by the melee attack.</param>
        public void Initialize(IHealth target, float damage)
        {
            playerHealth = target;
            attackDamage = damage;
        }
    }
}