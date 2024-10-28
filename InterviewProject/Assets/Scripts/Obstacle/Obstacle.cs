using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Obstruction
{
    /// <summary>
    /// Represents an obstacle that can damage the player on collision.
    /// </summary>
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] string playerNameTag; // Tag to identify the player.
        [SerializeField] float damage;  // Amount of damage dealt to the player.

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == playerNameTag)
            {
                // Deal damage to the player's health component.
                collision.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            }
        }
    }
}