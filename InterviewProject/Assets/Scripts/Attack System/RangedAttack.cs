using InterviewProject.TheObejctPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.AttackSystem
{
    /// <summary>
    /// Implements a ranged attack using a magic ball projectile.
    /// </summary>
    public class RangedAttack : BasicAttack
    {
        [SerializeField] protected Transform launchPos; // position where initialize magic ball

        protected ObjectPool magicBallPool; // object pool of magic ball
        protected float magicBallDamage; // damage it can deal
        protected string targetNameTag; // name tag of hit target

        /// <summary>
        /// Executes the ranged attack by firing a magic ball.
        /// </summary>
        public override void Attack()
        {
            FireMagicBall();
        }

        /// <summary>
        /// Fires a magic ball towards the target.
        /// Initializes and positions the magic ball.
        /// </summary>
        protected virtual void FireMagicBall()
        {
            // Get a magic ball from object pool
            GameObject magicBall = magicBallPool.GetObject();

            // Initialize the magic ball with target information and damage.
            magicBall.GetComponent<MagicBall>().Initialize(targetNameTag, magicBallDamage);

            // Set the position and rotation of the magic ball to the launch position.
            magicBall.transform.position = launchPos.position;
            magicBall.transform.rotation = launchPos.rotation;
            magicBall.SetActive(true);
        }
    }
}