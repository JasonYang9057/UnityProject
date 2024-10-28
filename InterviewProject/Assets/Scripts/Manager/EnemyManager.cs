using InterviewProject.TheEnemy;
using InterviewProject.Mechanic;
using InterviewProject.TheObejctPool;
using InterviewProject.GameProgression;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Manager
{
    /// <summary>
    /// Manages enemy behavior and interactions.
    /// </summary>
    public class EnemyManager : MonoBehaviour, IEnemyManager
    {
        // Object pool reference
        [SerializeField] ObjectPool objectPool;
        
        // Array of enemies
        IEnemy[] enemyObject;

        // List of enemy spawn positions
        private List<Vector3> enemySpawnPos;

        private void OnEnable()
        {
            GameEvents.OnReplayLevel += ResetEnemy;
        }

        private void OnDisable()
        {
            GameEvents.OnReplayLevel -= ResetEnemy;
        }

        private void Start()
        {
            // Find all enemies in the scene
            FindAllEnemy();
            // Initialize spawn positions list
            InitializeList();
        }

        /// <summary>
        /// Initializes the enemy manager with player health and transform.
        /// </summary>
        /// <param name="playerHealth">Player's health interface.</param>
        /// <param name="playerTrans">Player's transform.</param>
        public void Initialize(IHealth playerHealth, Transform playerTrans)
        {
            InitializeEnemies(playerHealth, playerTrans);
        }

        /// <summary>
        /// Find all enemies in the scene
        /// </summary>
        private void FindAllEnemy()
        {
            enemyObject = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        }

        /// <summary>
        /// Initialize spawn positions list
        /// </summary>
        private void InitializeList()
        {
            enemySpawnPos = new List<Vector3>(enemyObject.Length);
            for (int i = 0; i < enemyObject.Length; i++)
            {
                enemySpawnPos.Add((enemyObject[i] as Enemy).transform.position);
            }
        }

        /// <summary>
        /// Initializes the enemy with player health and transform.
        /// </summary>
        /// <param name="playerHealth">Player's health interface.</param>
        /// <param name="playerTrans">Player's transform.</param>
        private void InitializeEnemies(IHealth playerHealth, Transform playerTrans)
        {
            foreach (IEnemy enemy in enemyObject)
            {
                enemy.Initialize(objectPool, playerHealth, playerTrans);
            }
        }

        /// <summary>
        /// Gets the number of enemies managed.
        /// </summary>
        /// <returns>The count of enemies.</returns>
        public int GetEnemyCount()
        {
            return enemyObject.Length;
        }

        /// <summary>
        /// Resets all enemies to their spawn positions and activates them.
        /// </summary>
        public void ResetEnemy()
        {
            for (int i = 0; i < enemyObject.Length; i++)
            {
                (enemyObject[i] as Enemy).gameObject.transform.position = enemySpawnPos[i];
                (enemyObject[i] as Enemy).ResetEnemy();
                (enemyObject[i] as Enemy).gameObject.SetActive(true);
            }
        }
    }
}