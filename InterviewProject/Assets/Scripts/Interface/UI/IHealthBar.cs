using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.UI
{
    /// <summary>
    /// Defines a contract for health bar to subscribe action
    /// </summary>
    public interface IHealthBar
    {
        /// <summary>
        /// Subscribes to health changes from the specified health component.
        /// </summary>
        /// <param name="health">The health component to subscribe to for updates.</param>
        public void SubscribeAction(IHealth health);
    }
}