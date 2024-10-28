using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Manager
{
    /// <summary>
    /// Defines methods for managing game states and scene transitions.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Loads the next level in the game.
        /// </summary>
        public void NextLevel();

        /// <summary>
        /// Restarts the current level.
        /// </summary>
        public void ReplayLevel();

        /// <summary>
        /// Returns to the main menu.
        /// </summary>
        public void ReturnToMainMenu();

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void Quit();

        /// <summary>
        /// Retrieves the instance of the game manager.
        /// </summary>
        /// <returns>The game manager instance.</returns>
        public IGameManager GetGameManager();

        /// <summary>
        /// Checks if the current scene is the last scene in the game.
        /// </summary>
        /// <returns>True if it is the last scene; otherwise, false.</returns>
        public bool IsLastScene();
    }
}