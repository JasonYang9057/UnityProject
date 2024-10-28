using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InterviewProject.AttackSystem
{
    /// <summary>
    /// This abstract class defines the structure for attack actions that derived classes must implement.
    /// </summary>
    public abstract class BasicAttack : MonoBehaviour, IAttack
    {
        /// <summary>
        /// Executes an attack action, to be implemented by derived classes
        /// </summary>
        public abstract void Attack();
    }
}