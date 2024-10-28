using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Camera
{
    /// <summary>
    /// Defines a contract for camera to update based on mouse movement.
    /// </summary>
    public interface ICam
    {
        /// <summary>
        /// Updates the camera position/rotation based on mouse input.
        /// </summary>
        /// <param name="mouseX">The mouse movement on the X-axis.</param>
        /// <param name="mouseY">The mouse movement on the Y-axis.</param>
        public void UpdateCamera(float mouseX, float mouseY);
    }
}