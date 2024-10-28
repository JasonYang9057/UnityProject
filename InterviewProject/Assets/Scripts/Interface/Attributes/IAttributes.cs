using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Attribute
{
    /// <summary>
    /// Defines character attributes for use in ScriptableObjects.
    /// </summary>
    public interface IAttributes
    {
        float MaxHealth { get; } // Maximum health of the character.
        float MoveSpeed { get; } // Movement speed of the character.
        float AttackDamage { get; } // Damage dealt per attack.
        float AttackSpeed { get; } // Speed of attack actions.
    }

}