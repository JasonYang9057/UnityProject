using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.GameProgression
{
    /// <summary>
    /// Static class for managing game events and actions.
    /// </summary>
    public static class GameEvents
    {
        /// <summary>
        /// Event triggered when a new scene is loading.
        /// </summary>
        public static event Action OnLoadingNewScene;

        /// <summary>
        /// Event triggered when a new scene has finished loading.
        /// </summary>
        public static event Action OnNewSceneLoaded;

        /// <summary>
        /// Event triggered when the kill counter is increased.
        /// </summary>
        public static event Action OnKillCounterIncrease;

        /// <summary>
        /// Event triggered to replay the current level.
        /// </summary>
        public static event Action OnReplayLevel;

        /// <summary>
        /// Event triggered when the game is over.
        /// </summary>
        public static event Action OnGameOver;

        /// <summary>
        /// Event triggered when the game is won.
        /// </summary>
        public static event Action OnGameWin;

        /// <summary>
        /// Triggers the loading new scene event.
        /// </summary>
        public static void TriggerLoadingNewScene()
        {
            OnLoadingNewScene?.Invoke();
        }

        /// <summary>
        /// Triggers the new scene loaded event.
        /// </summary>
        public static void TriggerNewSceneLoaded()
        {
            OnNewSceneLoaded?.Invoke();
        }

        /// <summary>
        /// Triggers the kill counter increase event.
        /// </summary>
        public static void TriggerKillEnemy()
        {
            OnKillCounterIncrease?.Invoke();
        }

        /// <summary>
        /// Triggers the replay level event.
        /// </summary>
        public static void TriggerReplayLevel()
        {
            OnReplayLevel?.Invoke();
        }

        /// <summary>
        /// Triggers the game over event.
        /// </summary>
        public static void TriggerGameOver()
        {
            OnGameOver?.Invoke();
        }

        /// <summary>
        /// Triggers the game win event.
        /// </summary>
        public static void TriggerGameWin()
        {
            OnGameWin?.Invoke();
        }
    }
}