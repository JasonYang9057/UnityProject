using InterviewProject.GameProgression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheObejctPool
{
    /// <summary>
    /// Abstract class that manages a pool of game objects for reuse.
    /// </summary>
    public abstract class ObjectPool : MonoBehaviour, IObjectPool
    {
        // Prefab for the objects in the pool.
        [SerializeField] protected GameObject objectPrefab;
        // Initial size of the object pool.
        [SerializeField] protected int initialPoolSize = 20;

        // List to hold the pooled objects.
        protected List<GameObject> pool;

        // Subscribe event
        protected void OnEnable()
        {
            GameEvents.OnReplayLevel += ResetObject;
        }

        // Unsubscribe event
        protected void OnDisable()
        {
            GameEvents.OnReplayLevel -= ResetObject;
        }

        /// <summary>
        /// Initializes the object pool by creating a specified number of inactive objects.
        /// </summary>
        protected virtual void InitializePool()
        {
            pool = new List<GameObject>(initialPoolSize);

            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(objectPrefab, transform);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }

        /// <summary>
        /// Retrieves an inactive object from the pool or expands the pool if none are available.
        /// </summary>
        /// <returns>An available GameObject from the pool.</returns>
        public virtual GameObject GetObject()
        {
            foreach (GameObject obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            // If no inactive object is available, expand the pool.
            return ExpandList();
        }

        /// <summary>
        /// Expands the object pool by creating a new object and adding it to the pool.
        /// </summary>
        /// <returns>The newly created GameObject.</returns>
        protected virtual GameObject ExpandList()
        {
            GameObject newObj = Instantiate(objectPrefab);
            pool.Add(newObj);
            return newObj;
        }

        /// <summary>
        /// Resets all objects in the pool to be inactive.
        /// </summary>
        protected void ResetObject()
        {
            foreach (GameObject obj in pool)
            {
                obj.SetActive(false);
            }
        }
    }
}