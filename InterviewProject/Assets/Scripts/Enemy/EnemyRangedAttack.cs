using InterviewProject.AttackSystem;
using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Handles ranged attack behavior for enemies, extending RangedAttack.
    /// </summary>
    public class EnemyRangedAttack : RangedAttack, IEnemyRangedAttack
    {
        private Transform player; // Reference to the player's transform.

        /// <summary>
        /// Initializes the enemy ranged attack with required parameters.
        /// </summary>
        /// <param name="pool">Object pool for managing projectiles.</param>
        /// <param name="target">Target transform for the attack.</param>
        /// <param name="nameTag">Tag to identify the target.</param>
        /// <param name="damage">Damage dealt by the ranged attack.</param>
        public void Initialize(ObjectPool pool, Transform target, string nameTag, float damage)
        {
            player = target;
            magicBallPool = pool;
            targetNameTag = nameTag;
            magicBallDamage = damage;
        }

        /// <summary>
        /// Executes the ranged attack towards the player.
        /// </summary>
        public override void Attack()
        {
            // Rotate to face the player
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            base.Attack();
        }
    }
}