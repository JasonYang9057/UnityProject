using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Attribute
{
    /// <summary>
    /// Defines character attributes for use in ScriptableObjects.
    /// </summary>
    public interface IPlayerAttributes : IAttributes
    {
        float JumpSpeed { get; } // Jump speed of character
        float RegenerationTime { get; } // Time taken for health regeneration.
        float RegeneraitonAmount { get; } // Amount of health regenerated.
        float Gravity { get; } // Gravity affecting the player.
        float GroundCheckRadius { get; } // Radius for ground detection.
        float MouseSensitiveX { get; } // Mouse sensitivity on the X-axis.
        float MouseSensitiveY { get; } // Mouse sensitivity on the Y-axis.
    }
}