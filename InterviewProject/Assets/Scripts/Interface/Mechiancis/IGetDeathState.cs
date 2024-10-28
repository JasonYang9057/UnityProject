using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Mechanic
{
    /// <summary>
    /// Interface for health components to return death state
    /// </summary>
    public interface IGetDeathState
    {
        /// <summary>
        /// Indicates if the entity is dead.
        /// </summary>
        /// <returns>True if dead; otherwise, false.</returns>
        public bool ReturnIsDead();
    }
}