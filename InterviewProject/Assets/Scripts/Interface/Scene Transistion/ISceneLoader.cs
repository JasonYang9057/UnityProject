using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.SceneTransition
{
    /// <summary>
    /// Defines a contract for scene loader to initialize and load next scene
    /// </summary>
    public interface ISceneLoader
    {
        /// <summary>
        /// Initializes the scene loader with a specified screen fader.
        /// </summary>
        /// <param name="fader">The screen fader used for scene transitions.</param>
        public void Initialize(IScreenFader fader);

        /// <summary>
        /// Loads the next scene based on the specified scene index.
        /// </summary>
        /// <param name="sceneIndex">The index of the scene to load.</param>
        public void LoadNextScene(int sceneIndex);
    }
}