using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Camera
{
    /// <summary>
    /// Controls the player's camera rotation based on mouse input.
    /// </summary>
    public class PlayerCam : MonoBehaviour, ICam
    {
        [SerializeField] Transform body; // The player's body transform for horizontal rotation.
        private float xRotation; // Current vertical rotation of the camera.

        /// <summary>
        /// Updates the camera rotation based on mouse movement.
        /// </summary>
        /// <param name="mouseX">Mouse movement on the X-axis.</param>
        /// <param name="mouseY">Mouse movement on the Y-axis.</param>
        public void UpdateCamera(float mouseX, float mouseY)
        {
            // Clamp vertical rotation to prevent flipping.
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Rotate the player's body.
            body.Rotate(Vector3.up * mouseX);

            // Apply camera vertical rotation.
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
    }
}