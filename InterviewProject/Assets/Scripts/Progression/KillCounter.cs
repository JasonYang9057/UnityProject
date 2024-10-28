using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using InterviewProject.Manager;

namespace InterviewProject.GameProgression
{
    /// <summary>
    /// Manages the kill counter and checks win conditions in the game.
    /// </summary>
    public class KillCounter : MonoBehaviour, IKillCounter
    {
        [SerializeField] TMP_Text killCounterText; // Text component to display the kill count
        [SerializeField] string displayText; // Text to display before the kill count

        private IGameManager gameManager; // Reference to the game manager
        private int killCount = 0; // Current number of kills
        private int winCount; // Number of kills required to win

        // Subscribe event
        private void OnEnable()
        {
            GameEvents.OnKillCounterIncrease += IncreaseKillCounter;
            GameEvents.OnReplayLevel += ResetKillCount;
        }

        // Unsubscribe event
        private void OnDisable()
        {
            GameEvents.OnKillCounterIncrease -= IncreaseKillCounter;
            GameEvents.OnReplayLevel -= ResetKillCount;
        }

        /// <summary>
        /// Initializes the kill counter with a game manager and the win count.
        /// </summary>
        /// <param name="gameManager">Reference to the game manager.</param>
        /// <param name="amount">Number of kills required to win.</param>
        public void Initialize(IGameManager gameManager, int amount)
        {
            this.gameManager = gameManager;
            winCount = amount;
            UpdateDisplayText();
        }

        /// <summary>
        /// Increases the kill count and updates the display text.
        /// </summary>
        private void IncreaseKillCounter()
        {
            killCount++;
            UpdateDisplayText();
            CheckWinCondition();
        }

        /// <summary>
        /// Resets the kill count to zero and updates the display text.
        /// </summary>
        private void ResetKillCount()
        {
            killCount = 0;
            UpdateDisplayText();
        }

        /// <summary>
        /// Checks if the kill count meets the win condition.
        /// </summary>
        private void CheckWinCondition()
        {
            if (killCount >= winCount)
            {
                if (gameManager.IsLastScene())
                {
                    // Trigger game win event
                    GameEvents.TriggerGameWin();
                }
                else
                {
                    // Go next level
                    gameManager.NextLevel();
                }
            }
        }

        /// <summary>
        /// Updates the displayed kill count text.
        /// </summary>
        private void UpdateDisplayText()
        {
            killCounterText.text = displayText + killCount + "/" + winCount;
        }
    }
}