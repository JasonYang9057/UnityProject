using InterviewProject.AttackSystem;
using InterviewProject.Attribute;
using InterviewProject.Camera;
using InterviewProject.Mechanic;
using InterviewProject.GameProgression;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Handles player input for movement, jumping, camera control, and attacking.
    /// </summary>
    public class PlayerInput : MonoBehaviour, IInput
    {
        private IMovement playerMovement;  // Interface for player movement.
        private IJump playerJump;  // Interface for player jumping.
        private ICam playerCam;  // Interface for camera control.
        private IAttack playerAttack;  // Interface for player attack actions.

        private float mouseSensX;  // Mouse sensitivity for X-axis.
        private float mouseSensY;  // Mouse sensitivity for Y-axis.
        private bool inputLock = true;  // Determines if input is locked.

        // Subscribe event
        private void OnEnable()
        {
            GameEvents.OnLoadingNewScene += LockInput;
            GameEvents.OnGameOver += LockInput;
            GameEvents.OnGameWin += LockInput;

            GameEvents.OnNewSceneLoaded += UnLockInput;
            GameEvents.OnReplayLevel += UnLockInput;
        }

        // Unsubscribe event
        private void OnDisable()
        {
            GameEvents.OnLoadingNewScene += LockInput;
            GameEvents.OnGameOver -= LockInput;
            GameEvents.OnGameWin -= LockInput;

            GameEvents.OnNewSceneLoaded -= UnLockInput;
            GameEvents.OnReplayLevel -= UnLockInput;
        }

        /// <summary>
        /// Initializes the player input system with movement, camera, and attack interfaces.
        /// </summary>
        /// <param name="movement">The movement interface for the player.</param>
        /// <param name="cam">The camera interface for the player.</param>
        /// <param name="attack">The attack interface for the player.</param>
        public void Initialize(IMovement movement, ICam cam, IAttack attack)
        {
            playerMovement = movement;
            playerJump = movement as IJump;
            playerCam = cam;
            playerAttack = attack;

            // Unlock input
            inputLock = false;
        }

        /// <summary>
        /// Sets mouse sensitivity attributes for player input.
        /// </summary>
        /// <param name="attributes">The player attributes containing sensitivity settings.</param>
        public void SetAttributes(IAttributes attributes)
        {
            IPlayerAttributes playerAttributes = attributes as IPlayerAttributes;

            mouseSensX = playerAttributes.MouseSensitiveX;
            mouseSensY = playerAttributes.MouseSensitiveY;
        }

        private void Update()
        {
            if (!inputLock)
            {
                ReadMouseInput();
                ReadKeyboardInput();
            }
        }

        /// <summary>
        /// Reads mouse input to control the camera and trigger attacks.
        /// </summary>
        public void ReadMouseInput()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensX * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensY * Time.deltaTime;
            if (mouseX != 0 || mouseY != 0)
            {
                playerCam.UpdateCamera(mouseX, mouseY);
            }

            if (Input.GetMouseButtonDown(0))
            {
                playerAttack.Attack();
            }
        }

        /// <summary>
        /// Reads keyboard input for player movement and jumping.
        /// </summary>
        private void ReadKeyboardInput()
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (direction != Vector3.zero)
            {

                playerMovement.MoveTo(direction);
            }

            if (Input.GetButtonDown("Jump"))
            {
                playerJump.Jump();
            }
        }

        /// <summary>
        /// Locks player input to prevent any action.
        /// </summary>
        private void LockInput()
        {
            inputLock = true;
        }

        /// <summary>
        /// Unlocks player input to allow actions.
        /// </summary>
        private void UnLockInput()
        {
            inputLock = false;
        }
    }
}