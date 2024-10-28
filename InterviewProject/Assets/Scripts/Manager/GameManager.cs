using InterviewProject.GameProgression;
using InterviewProject.ThePlayer;
using InterviewProject.SceneTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace InterviewProject.Manager
{
    /// <summary>
    /// Manages game states, scene transitions, and game events.
    /// </summary>
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private int sceneCount; // Total number of scenes in the build
        [SerializeField] private int currentScene = 0; // Index of the current scene

        [SerializeField] SceneLoader sceneLoader; // Scene loader component
        [SerializeField] ScreenFader screenFader; // Screen fader component

        public UnityEvent OnGameLose; // Event triggered on game over

        // Subscribe event
        private void OnEnable()
        {
            GameEvents.OnNewSceneLoaded += FindComponents;
            GameEvents.OnGameOver += GameOver;
            GameEvents.OnGameWin += GameWin;
        }

        // Unsubscribe event
        private void OnDisable()
        {
            GameEvents.OnNewSceneLoaded -= FindComponents;
            GameEvents.OnGameOver -= GameOver;
            GameEvents.OnGameWin -= GameWin;
        }

        private void Start()
        {
            // Initialize sceneLoader with screenFader
            sceneLoader.Initialize(screenFader);
            // Set total scenes
            sceneCount = SceneManager.sceneCountInBuildSettings - 1;
        }

        /// <summary>
        /// Finds and initializes necessary components in the current scene.
        /// </summary>
        private void FindComponents()
        {
            // Skip finding components in the main menu scene
            if (currentScene != 0)
            {
                // Find components in active scene
                IKillCounter killCounter = FindAnyObjectByType<KillCounter>();
                IEnemyManager enemyManager = FindAnyObjectByType<EnemyManager>();
                IPlayer player = FindAnyObjectByType<Player>();

                //Initializes the components with required dependencies.
                InitializeComponents(killCounter, enemyManager, player);
            }
        }

        /// <summary>
        /// Initializes the components with required dependencies.
        /// </summary>
        /// <param name="killCounter">The kill counter component.</param>
        /// <param name="enemyManager">The enemy manager component.</param>
        /// <param name="player">The player component.</param>
        private void InitializeComponents(IKillCounter killCounter, IEnemyManager enemyManager, IPlayer player)
        {
            // Initialize killerCounter with gameManager, enemy count
            killCounter.Initialize(this, enemyManager.GetEnemyCount());
            // Initialize enemyManager with player health, player transformation
            enemyManager.Initialize(player.GetPlayerHealth(), player.GetPlayerTransform());
        }

        /// <summary>
        /// Handles the game over state.
        /// </summary>
        public void GameOver()
        {
            // Trigger game lose event
            OnGameLose?.Invoke();

            // Pause game
            Time.timeScale = 0;
            // Unlock and show cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /// <summary>
        /// Handles the game win state.
        /// </summary>
        public void GameWin()
        {
            // Pause game
            Time.timeScale = 0;

            // Unlock and show cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /// <summary>
        /// Loads the next level.
        /// </summary>
        public void NextLevel()
        {
            currentScene++;
            if (currentScene > sceneCount)
            {
                // Reset to first scene
                currentScene = 1;
            }

            // Lock and hide cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // Resume game
            Time.timeScale = 1;

            // Load next scene
            sceneLoader.LoadNextScene(currentScene);
        }

        /// <summary>
        /// Replays the current level.
        /// </summary>
        public void ReplayLevel()
        {
            // Lock and hide cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // Resume game
            Time.timeScale = 1;

            // Trigger static replay level event
            GameEvents.TriggerReplayLevel();
        }

        /// <summary>
        /// Returns to the main menu.
        /// </summary>
        public void ReturnToMainMenu()
        {
            // Set to main menu scene
            currentScene = 0;

            // Unlock and show cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Resume game
            Time.timeScale = 1;

            // Load main menu scene
            sceneLoader.LoadNextScene(currentScene);
        }

        /// <summary>
        /// Exits the game application.
        /// </summary>
        public void Quit()
        {
            // Close game
            Application.Quit();
        }

        /// <summary>
        /// Gets the current instance of the game manager.
        /// </summary>
        /// <returns>The game manager instance.</returns>
        public IGameManager GetGameManager()
        {
            return this;
        }

        /// <summary>
        /// Checks if the current scene is the last one in the game.
        /// </summary>
        /// <returns>True if it is the last scene; otherwise, false.</returns>
        public bool IsLastScene()
        {
            return (currentScene == sceneCount);
        }
    }
}