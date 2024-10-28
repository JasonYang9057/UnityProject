using InterviewProject.GameProgression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Manager
{
    /// <summary>
    /// Manages UIs
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        [SerializeField] GameObject gameOverMenu; // Game over UI
        [SerializeField] GameObject gameWinMenu; // Win UI

        private void OnEnable()
        {
            GameEvents.OnGameOver += TurnOnGameOverMenu;
            GameEvents.OnGameWin += TurnOnWinMenu;
            GameEvents.OnReplayLevel += TurnOffMenus;
        }

        private void OnDisable()
        {
            GameEvents.OnGameOver -= TurnOnGameOverMenu;
            GameEvents.OnGameWin -= TurnOnWinMenu;
            GameEvents.OnReplayLevel -= TurnOffMenus;
        }

        /// <summary>
        /// Activates the game over menu.
        /// </summary>
        private void TurnOnGameOverMenu()
        {
            gameOverMenu.SetActive(true);
        }

        /// <summary>
        /// Deactivates the game over and win menus.
        /// </summary>
        private void TurnOffMenus()
        {
            gameOverMenu.SetActive(false);
            gameWinMenu.SetActive(false);
        }

        /// <summary>
        /// Activates the win menu.
        /// </summary>
        private void TurnOnWinMenu()
        {
            gameWinMenu.SetActive(true);
        }
    }
}