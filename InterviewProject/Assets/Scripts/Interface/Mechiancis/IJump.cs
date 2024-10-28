using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Mechanic
{
    /// <summary>
    /// Defines a contract for jump behavior.
    /// </summary>
    public interface IJump
    {
        /// <summary>
        /// Executes the jump action.
        /// </summary>
        public void Jump();
    }
}