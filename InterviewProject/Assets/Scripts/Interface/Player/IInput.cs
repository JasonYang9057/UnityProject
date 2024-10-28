using InterviewProject.AttackSystem;
using InterviewProject.Attribute;
using InterviewProject.Camera;
using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.ThePlayer
{
    /// <summary>
    /// Defines a contract for input initialization and set attributes
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// Initializes the input system with movement, camera, and attack components.
        /// </summary>
        /// <param name="movement">The movement component to be used.</param>
        /// <param name="cam">The camera component to be used.</param>
        /// <param name="attack">The attack component to be used.</param>
        public void Initialize(IMovement movement, ICam cam, IAttack attack);

        /// <summary>
        /// Sets the attributes for the input system.
        /// </summary>
        /// <param name="attributes">The attributes to be assigned to the input.</param>
        public void SetAttributes(IAttributes attributes);
    }
}