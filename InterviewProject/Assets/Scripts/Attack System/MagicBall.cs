using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.AttackSystem
{
    /// <summary>
    /// Represents a magic projectile that moves forward and deals damage on collision.
    /// </summary>
    public class MagicBall : MonoBehaviour, IMagicBall
    {
        [SerializeField] float speed;  // Speed of the magic ball.
        [SerializeField] float lifeTime; // Time before the magic ball deactivates.

        private float damage; // Damage dealt to the target.
        private string targetTagName; // Tag name of the target to detect collision.
        private float existTime; // Time the magic ball has existed.

        private void OnEnable()
        {
            existTime = 0f;
        }

        private void Update()
        {
            Movement();
            CheckLifeTime();
        }

        /// <summary>
        /// Moves the magic ball forward based on its speed.
        /// </summary>
        private void Movement()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        /// <summary>
        /// Deactivates the magic ball if it exceeds its lifetime.
        /// </summary>
        private void CheckLifeTime()
        {
            existTime += Time.deltaTime;
            if (existTime > lifeTime)
            {
                gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Initializes the magic ball with a target tag and damage value.
        /// </summary>
        /// <param name="tagName">Tag name of the target.</param>
        /// <param name="damage">Damage dealt to the target.</param>
        public void Initialize(string tagName, float damage)
        {
            targetTagName = tagName;
            this.damage = damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == targetTagName)
            {
                // Deal damage to the target's health component.
                collision.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            }

            gameObject.SetActive(false);
        }
    }
}