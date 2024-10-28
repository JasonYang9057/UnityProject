using InterviewProject.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InterviewProject.UI
{
    /// <summary>
    /// Manages the win menu displayed when the player wins the game.
    /// Provides options to restart the level, return to the main menu, or quit the game.
    /// </summary>
    public class WinMenu : Menu
    {
        [SerializeField] Button gameStartOverButton; // Button to restart the game
        [SerializeField] Button mainMenuButton; // Button to return to the main menu
        [SerializeField] Button quitButton; // Button to quit the game

        private void Start()
        {
            IGameManager gameManager = FindAnyObjectByType<GameManager>();
            RegisterButtonEvents(gameManager);
        }

        /// <summary>
        /// Registers button events for the win menu buttons.
        /// </summary>
        /// <param name="gameManager">The game manager to handle actions for each button.</param>
        protected override void RegisterButtonEvents(IGameManager gameManager)
        {
            gameStartOverButton.onClick.AddListener(gameManager.NextLevel);
            mainMenuButton.onClick.AddListener(gameManager.ReturnToMainMenu);
            quitButton.onClick.AddListener(gameManager.Quit);
        }
    }
}