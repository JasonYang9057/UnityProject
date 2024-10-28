using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.AttackSystem
{
    /// <summary>
    /// Defines a contract for magic ball to be initialized.
    /// </summary>
    public interface IMagicBall
    {
        /// <summary>
        /// Initializes the magic ball with a tag name and damage amount.
        /// </summary>
        /// <param name="tagName">The name tag for the magic.</param>
        /// <param name="damage">The damage amount.</param>
        public void Initialize(string tagName, float damage);
    }
}