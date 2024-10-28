using InterviewProject.AttackSystem;
using InterviewProject.Attribute;
using InterviewProject.Mechanic;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Represents the possible states of an enemy.
    /// </summary>
    public enum EnemyState
    {
        Move, // Enemy is moving.
        Attack, // Enemy is attacking.
        Die // Enemy is dead.
    }

    /// <summary>
    /// Manages enemy AI behavior, including movement, attack, and death states.
    /// </summary>
    public class EnemyAI : MonoBehaviour, IAI
    {
        private IHealth enemyHealth; // Health component of the enemy.
        private IAttack enemyAttack; // Attack behavior of the enemy.
        private IMovement enemyMovement; // Movement behavior of the enemy.

        private Transform playerTrans; // Player's transform reference.
        private float attackRange; // Distance within which the enemy can attack.
        private float attackSpeed; // Time between attacks.

        private EnemyState currState; // Current state of the enemy.
        private float lastAttackTime; // Timer to track attack availability.
        private bool isReady = false; // Indicates if the enemy is initialized.

        private void OnEnable()
        {
            // Set initial state to Move.
            currState = EnemyState.Move;
        }

        /// <summary>
        /// Initializes the enemy AI with required components and player transform.
        /// </summary>
        /// <param name="health">Health component of the enemy.</param>
        /// <param name="attack">Attack behavior of the enemy.</param>
        /// <param name="movement">Movement behavior of the enemy.</param>
        /// <param name="trans">Transformation of the player.</param>
        public void Initialize(IHealth health, IAttack attack, IMovement movement, Transform trans)
        {
            enemyHealth = health;
            enemyAttack = attack;
            enemyMovement = movement;
            playerTrans = trans;

            // Enemy AI is ready to run
            isReady = true;
        }

        private void Update()
        {
            // Switch action base on state
            if (isReady)
            {
                switch (currState)
                {
                    case EnemyState.Move:
                        HandleMove();
                        break;
                    case EnemyState.Attack:
                        HandleAttack();
                        break;
                    case EnemyState.Die:
                        HandleDie();
                        break;
                }

                // Counting attack time
                lastAttackTime += Time.deltaTime;
            }
        }

        /// <summary>
        /// Sets the enemy's attributes from the given attribute data.
        /// </summary>
        /// <param name="attribute">The enemy's attributes.</param>
        public void SetAttributes(IAttributes attribute)
        {
            attackRange = (attribute as IEnemyAttributes).AttackRange;
            attackSpeed = attribute.AttackSpeed;

            // Avaliable to attack
            lastAttackTime = attackSpeed + 1;
        }

        /// <summary>
        /// Handles the enemy's movement towards the player.
        /// </summary>
        private void HandleMove()
        {
            // If player is dead, change state
            if (CheckDeath())
            {
                currState = EnemyState.Die;
            }

            // Move enemy towards player
            enemyMovement.MoveTo(playerTrans.position);

            // If player is in attack range, change state
            if (IsPlayerInAttackRange())
            {
                currState = EnemyState.Attack;
            }
        }

        /// <summary>
        /// Checks if the player is within attack range.
        /// </summary>
        /// <returns>True if the player is in range; otherwise, false.</returns>
        private bool IsPlayerInAttackRange()
        {
            if (Vector3.Distance(transform.position, playerTrans.position) > attackRange)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Handles the enemy's attack behavior.
        /// </summary>
        private void HandleAttack()
        {
            // Stop enemy movement for attack action
            (enemyMovement as IStopAgent).StopAgent();

            // If player is dead, change state
            if (CheckDeath())
            {
                currState = EnemyState.Die;
            }

            // If is ready, attack
            if (CheckAttackAvaliable())
            {
                enemyAttack.Attack();
            }

            // If player is out of attack range, change state
            if (!IsPlayerInAttackRange())
            {
                currState = EnemyState.Move;
            }
        }

        /// <summary>
        /// Checks if the enemy is dead.
        /// </summary>
        /// <returns>True if dead; otherwise, false.</returns>
        private bool CheckDeath()
        {
            return (enemyHealth as EnemyHealth).ReturnIsDead();
        }

        /// <summary>
        /// Checks if the enemy can attack based on the attack speed.
        /// </summary>
        /// <returns>True if attack is available; otherwise, false.</returns>
        private bool CheckAttackAvaliable()
        {
            if(lastAttackTime > attackSpeed)
            {
                lastAttackTime = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Handles the enemy's death behavior.
        /// </summary>
        private void HandleDie()
        {
            gameObject.SetActive(false);
        }
    }
}