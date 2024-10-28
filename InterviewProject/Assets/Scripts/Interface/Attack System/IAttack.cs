using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.AttackSystem
{
    /// <summary>
    /// Provides an interface for attack actions that can be implemented by various game entities.
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// Executes an attack action for the implementing entity.
        /// </summary>
        void Attack();
    }
}