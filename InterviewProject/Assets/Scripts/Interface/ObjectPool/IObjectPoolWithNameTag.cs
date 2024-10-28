using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.TheObejctPool
{
    /// <summary>
    /// Defines a contract for object pool to provide name tag.
    /// </summary>
    public interface IObjectPoolWithNameTag
    {
        /// <summary>
        /// Gets the name tag of the object pool.
        /// </summary>
        /// <returns>Name tag as a string.</returns>
        public string GetNameTag();
    }
}