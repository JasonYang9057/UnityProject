using InterviewProject.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InterviewProject.UI
{
    /// <summary>
    /// Represents the main menu of the game, providing options to start the game or quit.
    /// </summary>
    public class MainMenu : Menu
    {
        [SerializeField] Button gameStartButton; // Button to start the game
        [SerializeField] Button quitButton;       // Button to quit the game

        /// <summary>
        /// Initializes the main menu by finding the game manager and registering button events.
        /// </summary>
        private void Start()
        {
            IGameManager gameManager = FindAnyObjectByType<GameManager>();
            RegisterButtonEvents(gameManager);
        }

        /// <summary>
        /// Registers the click events for the menu buttons using the provided game manager.
        /// </summary>
        /// <param name="gameManager">The game manager used to handle level transitions and quitting.</param>
        protected override void RegisterButtonEvents(IGameManager gameManager)
        {
            gameStartButton.onClick.AddListener(gameManager.NextLevel);
            quitButton.onClick.AddListener(gameManager.Quit);
        }
    }
}