using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheObejctPool
{
    /// <summary>
    /// Manages a pool of magic ball objects.
    /// </summary>
    public class MagicBallObjectPool : ObjectPool, IObjectPoolWithNameTag
    {
        [SerializeField] string targetNameTag; // Tag for identifying the magic ball.
        [SerializeField] Material magicBallMaterial; // Material for the magic ball.

        private void Awake()
        {
            InitializePool();
        }

        /// <summary>
        /// Initializes the object pool and sets materials for existing objects.
        /// </summary>
        protected override void InitializePool()
        {
            base.InitializePool();

            // Set the material for each object in the pool.
            foreach (GameObject obj in pool)
            {
                obj.GetComponentInChildren<Renderer>().material = magicBallMaterial;
            }
        }

        /// <summary>
        /// Expands the object pool by creating a new magic ball object.
        /// </summary>
        /// <returns>The newly created GameObject.</returns>
        protected override GameObject ExpandList()
        {
            // Instantiate a new magic ball object and assign material.
            GameObject newObj = Instantiate(objectPrefab);
            newObj.GetComponentInChildren<Renderer>().material = magicBallMaterial;
            pool.Add(newObj);
            return newObj;
        }

        /// <summary>
        /// Gets the name tag for the object pool.
        /// </summary>
        /// <returns>Name tag as a string.</returns>
        public string GetNameTag()
        {
            return targetNameTag;
        }
    }
}