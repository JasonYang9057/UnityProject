using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Attribute
{
    /// <summary>
    /// Defines character attributes for use in ScriptableObjects.
    /// </summary>
    public interface IEnemyAttributes : IAttributes
    {
        float AttackRange { get; } // Range within which the enemy can attack.
    }
}