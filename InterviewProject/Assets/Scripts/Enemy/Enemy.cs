using InterviewProject.AttackSystem;
using InterviewProject.Attribute;
using InterviewProject.Mechanic;
using InterviewProject.UI;
using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Manages enemy behavior and interactions.
    /// </summary>
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] EnemyAI enemyAI; // AI behavior of the enemy
        [SerializeField] HealthBar enemyHealthBar; // UI element displaying enemy health
        [SerializeField] Health enemyHealth; // Health management for the enemy
        [SerializeField] BasicAttack enemyAttack; // Attack behavior of the enemy
        [SerializeField] EnemyMovement enemyMovement; // Movement behavior of the enemy
        [SerializeField] EnemyAttributes enemyAttributes; // Enemy's attributes data

        private void Start()
        {
            // Subscribe health updates to the health bar
            enemyHealthBar.SubscribeAction(enemyHealth);
            // Set AI attributes
            enemyAI.SetAttributes(enemyAttributes);
            // Set movement attributes
            enemyMovement.SetAttributes(enemyAttributes);
            // Initialize enemy health
            enemyHealth.SetHealth(enemyAttributes.MaxHealth);
        }

        /// <summary>
        /// Initializes the enemy with the provided pool and player references.
        /// </summary>
        /// <param name="pool">The object pool for enemy projectiles.</param>
        /// <param name="health">Reference to the player's health.</param>
        /// <param name="trans">Reference to the player's transform.</param>
        public void Initialize(ObjectPool pool, IHealth health, Transform trans)
        {
            ObjectPool objectPool = pool;
            IHealth playerHealth = health; 
            Transform playerTrans = trans;

            // Initialize attack behavior based on attack type
            if (enemyAttack is IEnemyMeleeAttack)
            {
                (enemyAttack as IEnemyMeleeAttack).Initialize(playerHealth, enemyAttributes.AttackDamage);
            }
            else if (enemyAttack is IEnemyRangedAttack)
            {
                (enemyAttack as IEnemyRangedAttack).Initialize
                    (objectPool, playerTrans,
                    (pool as MagicBallObjectPool).GetNameTag(),
                    enemyAttributes.AttackDamage);
            }

            // Initialize AI with health, attack, and movement references
            enemyAI.Initialize(enemyHealth, enemyAttack, enemyMovement, playerTrans);
        }

        /// <summary>
        /// Resets the enemy's health to revive it.
        /// </summary>
        public void ResetEnemy()
        {
            enemyHealth.Revive();
        }
    }
}