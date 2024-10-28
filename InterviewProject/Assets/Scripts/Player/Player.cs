using InterviewProject.AttackSystem;
using InterviewProject.Attribute;
using InterviewProject.Camera;
using InterviewProject.Mechanic;
using InterviewProject.TheObejctPool;
using InterviewProject.UI;
using InterviewProject.GameProgression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Represents the player character with input, movement, camera, and health management.
    /// </summary>
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] PlayerInput playerInput;  // Handles player input.
        [SerializeField] PlayerMovement playerMovement;  // Manages player movement.
        [SerializeField] PlayerCam playerCam;  // Controls the camera behavior.
        [SerializeField] PlayerAttributes playerAttributes;  // Player attributes like health and attack.
        [SerializeField] Health playerHealth;  // Manages player's health.
        [SerializeField] BasicAttack playerAttack;  // Manages player attack actions.
        [SerializeField] HealthBar playerHealthBar;  // UI element to display health.
        [SerializeField] ObjectPool magicBallPool;  // Pool for magic ball projectiles.

        private Vector3 spawnPos; // Player's spawn position.

        // Subscribe action
        private void OnEnable()
        {
            GameEvents.OnReplayLevel += RevivePlayer;
        }

        // Unsubscribe action
        private void OnDisable()
        {
            GameEvents.OnReplayLevel -= RevivePlayer;
        }

        private void Start()
        {
            // Subscribe the health bar to the player's health for updates.
            playerHealthBar.SubscribeAction(playerHealth);

            // Initialize input, attack, and attributes.
            playerInput.Initialize(playerMovement, playerCam, playerAttack);
            (playerAttack as PlayerAttack).Initialize(magicBallPool,
                (magicBallPool as MagicBallObjectPool).GetNameTag(),
                playerAttributes.AttackDamage,
                playerAttributes.AttackSpeed);

            // Set attributes
            playerInput.SetAttributes(playerAttributes);
            playerMovement.SetAttributes(playerAttributes);

            // Set player's initial health based on attributes.
            playerHealth.SetHealth(playerAttributes.MaxHealth);
            (playerHealth as PlayerHealth).Initialize(playerAttributes);

            // Store the initial spawn position
            spawnPos = transform.position;
        }

        /// <summary>
        /// Revives the player by resetting their position and health.
        /// </summary>
        public void RevivePlayer()
        {
            transform.position = spawnPos;
            playerHealth.Revive();
        }

        /// <summary>
        /// Gets the player's health component.
        /// </summary>
        /// <returns>The player's health interface.</returns>
        public IHealth GetPlayerHealth()
        {
            return playerHealth;
        }

        /// <summary>
        /// Gets the player's transform component.
        /// </summary>
        /// <returns>The player's transform.</returns>
        public Transform GetPlayerTransform()
        {
            return transform;
        }
    }
}