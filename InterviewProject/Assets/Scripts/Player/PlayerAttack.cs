using InterviewProject.AttackSystem;
using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Manages player attack actions using ranged attacks.
    /// </summary>
    public class PlayerAttack : RangedAttack, IPlayerAttack
    {
        private float lastAttackTime; // Tracks the time since the last attack.
        private float attackSpeed; // The speed at which the player can attack.

        public UnityEvent OnPlayerAttack; // Event triggered when the player attacks.

        /// <summary>
        /// Initializes the player attack parameters.
        /// </summary>
        /// <param name="pool">The object pool for managing attack projectiles.</param>
        /// <param name="nameTag">The name tag for identifying target objects.</param>
        /// <param name="damgae">The damage dealt by the attack.</param>
        /// <param name="attackSpeed">The speed of the attack.</param>
        public void Initialize(ObjectPool pool, string nameTag, float damgae, float attackSpeed)
        {
            magicBallPool = pool;
            targetNameTag = nameTag;
            magicBallDamage = damgae;
            this.attackSpeed = attackSpeed;
            lastAttackTime = attackSpeed + 1f;
        }

        private void Update()
        {
            lastAttackTime += Time.deltaTime;
        }

        /// <summary>
        /// Performs the attack if the attack speed allows it.
        /// </summary>
        public override void Attack()
        {
            if (lastAttackTime > attackSpeed)
            {
                lastAttackTime = 0f;
                // Trigger player attack event
                OnPlayerAttack?.Invoke();
                base.Attack();
            }
        }
    }
}