using InterviewProject.AttackSystem;
using InterviewProject.Attribute;
using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Interface for AI behavior, providing methods to initialize and set attributes.
    /// </summary>
    public interface IAI
    {
        /// <summary>
        /// Initializes the AI with necessary components and transform.
        /// </summary>
        /// <param name="health">Health component for the AI.</param>
        /// <param name="attack">Attack component for the AI.</param>
        /// <param name="movement">Movement component for the AI.</param>
        /// <param name="trans">Transform of the AI.</param>
        public void Initialize(IHealth health, IAttack attack, IMovement movement, Transform trans);

        /// <summary>
        /// Sets the attributes for the AI.
        /// </summary>
        /// <param name="attribute">Attributes to assign to the AI.</param>
        public void SetAttributes(IAttributes attribute);
    }
}