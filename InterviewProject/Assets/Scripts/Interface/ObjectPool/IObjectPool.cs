using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheObejctPool
{
    /// <summary>
    /// Defines a contract for an object pool, providing a method to retrieve game objects.
    /// </summary>
    public interface IObjectPool
    {
        /// <summary>
        /// Retrieves an object from the pool.
        /// </summary>
        /// <returns>A GameObject from the pool.</returns>
        public GameObject GetObject();
    }
}