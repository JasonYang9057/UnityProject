using InterviewProject.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace InterviewProject.UI
{
    /// <summary>
    /// Abstract base class for menus in the game. This class defines the structure for menu implementations.
    /// </summary>
    public abstract class Menu : MonoBehaviour
    {
        /// <summary>
        /// Registers button events with the provided game manager.
        /// This method must be implemented in derived classes to define specific button behaviors.
        /// </summary>
        /// <param name="gameManager">The game manager used to handle game-related actions.</param>
        protected abstract void RegisterButtonEvents(IGameManager gameManager);
    }
}