using InterviewProject.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InterviewProject.UI
{
    /// <summary>
    /// Represents the game over menu, allowing players to replay the level or quit the game.
    /// </summary>
    public class GameOverMenu : Menu
    {
        [SerializeField] Button gameReplayButton; // Button to replay the game
        [SerializeField] Button quitButton; // Button to quit the game

        /// <summary>
        /// Initializes the game over menu and registers button events.
        /// </summary>
        private void Start()
        {
            IGameManager gameManager = FindAnyObjectByType<GameManager>();
            RegisterButtonEvents(gameManager);
        }

        /// <summary>
        /// Registers the button events for the game over menu.
        /// </summary>
        /// <param name="gameManager">The game manager to manage game actions.</param>
        protected override void RegisterButtonEvents(IGameManager gameManager)
        {
            gameReplayButton.onClick.AddListener(gameManager.ReplayLevel);
            quitButton.onClick.AddListener(gameManager.Quit);
        }
    }
}