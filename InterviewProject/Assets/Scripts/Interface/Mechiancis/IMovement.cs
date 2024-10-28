using InterviewProject.Attribute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Mechanic
{
    /// <summary>
    /// Interface for movement behavior, defining methods for setting attributes and moving to a destination.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Sets the movement attributes for the implementing class.
        /// </summary>
        /// <param name="attributes">Attributes containing movement settings.</param>
        public void SetAttributes(IAttributes attributes);

        /// <summary>
        /// Moves the object to the specified destination.
        /// </summary>
        /// <param name="destination">Target position to move towards.</param>
        public void MoveTo(Vector3 destination);
    }
}