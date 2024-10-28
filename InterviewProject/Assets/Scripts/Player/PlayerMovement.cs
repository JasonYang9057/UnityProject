using InterviewProject.Attribute;
using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Manages player movement including walking and jumping, using Rigidbody physics.
    /// </summary>
    public class PlayerMovement : MonoBehaviour, IMovement, IJump
    {
        [SerializeField] Rigidbody rb; // Rigidbody component for physics-based movement.
        [SerializeField] Transform groundCheck; // Transform used to check if the player is on the ground.
        [SerializeField] LayerMask groundLayer; // Layer mask to identify ground layers.

        private float moveSpeed; // Speed of player movement.
        private float jumpSpeed; // Speed of player's jump.
        private float gravity; // Gravity effect on the player.
        private float groundCheckRadius; // Radius of the ground check sphere.
        private bool isGround; // Flag indicating whether the player is on the ground.

        public UnityEvent OnPlayerJump; // Event triggered when the player jumps.

        private void Update()
        {
            // Update gravity effects on the player.
            GravityMovement();
        }

        /// <summary>
        /// Sets movement attributes based on player attributes.
        /// </summary>
        /// <param name="attributes">The player attributes containing movement settings.</param>
        public void SetAttributes(IAttributes attributes)
        {
            PlayerAttributes playerAttributes = attributes as PlayerAttributes;

            moveSpeed = playerAttributes.MoveSpeed;
            jumpSpeed = playerAttributes.JumpSpeed;
            gravity = playerAttributes.Gravity;
            groundCheckRadius = playerAttributes.GroundCheckRadius;
        }

        /// <summary>
        /// Applies gravity effects based on whether the player is grounded.
        /// </summary>
        private void GravityMovement()
        {
            isGround = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

            if (isGround && rb.velocity.y < 0)
            {
                rb.drag = gravity;
            }
            else
            {
                rb.drag = 0;
            }
        }

        /// <summary>
        /// Moves the player in the specified direction.
        /// </summary>
        /// <param name="direction">The direction to move, where x is horizontal and z is forward/backward.</param>
        public void MoveTo(Vector3 direction)
        {
            Vector3 moveDirection = transform.forward * direction.z * moveSpeed + transform.right * direction.x * moveSpeed;
            rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
        }

        /// <summary>
        /// Makes the player jump if they are grounded.
        /// </summary>
        public void Jump()
        {
            if (isGround)
            {
                // Trigger jump event
                OnPlayerJump?.Invoke();

                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }
        }
    }
}