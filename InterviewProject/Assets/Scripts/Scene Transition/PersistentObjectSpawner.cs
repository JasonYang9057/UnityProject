using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.SceneTransition
{
    /// <summary>
    /// Spawns persistent objects that survive scene transitions.
    /// </summary>
    public class PersistentObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistentObjectPrefab; // Prefab for the persistent object to be spawned

        static bool hasSpawned = false; // Tracks whether the persistent object has already been spawned

        private void Awake()
        {
            // Only instantiate object once
            if (hasSpawned) return;

            SpawnPersistentObjects();

            hasSpawned = true;
        }

        /// <summary>
        /// Instantiates the persistent object and marks it to not be destroyed on load.
        /// </summary>
        private void SpawnPersistentObjects()
        {
            GameObject persistentObject = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentObject);
        }
    }
}