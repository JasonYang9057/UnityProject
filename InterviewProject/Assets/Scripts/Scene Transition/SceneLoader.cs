using InterviewProject.GameProgression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InterviewProject.SceneTransition
{
    /// <summary>
    /// Manages the loading of scenes with fade effects.
    /// </summary>
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] float fadeInTime = 1f; // Duration for fade-in effect
        [SerializeField] float fadeOutTime = 1f; // Duration for fade-out effect

        private IScreenFader screenFader; // Reference to the screen fader component

        /// <summary>
        /// Initializes the SceneLoader with a screen fader.
        /// </summary>
        /// <param name="fader">The screen fader used for scene transitions.</param>
        public void Initialize(IScreenFader fader)
        {
            screenFader = fader;
        }

        /// <summary>
        /// Loads the next scene asynchronously.
        /// </summary>
        /// <param name="sceneIndex">Index of the scene to load.</param>
        public void LoadNextScene(int sceneIndex)
        {
            StartCoroutine(LoadTargetScene(sceneIndex));
        }

        /// <summary>
        /// Coroutine that handles the loading of a target scene with fade effects.
        /// </summary>
        /// <param name="sceneIndex">Index of the scene to load.</param>
        /// <returns>IEnumerator for coroutine.</returns>
        private IEnumerator LoadTargetScene(int sceneIndex)
        {
            // Trigger load new scene event
            GameEvents.TriggerLoadingNewScene();

            // Fade out the current scene
            yield return screenFader.FadeOut(fadeOutTime);
            // Load the target scene asynchronously
            yield return SceneManager.LoadSceneAsync(sceneIndex);
            // Fade in the current scene
            yield return screenFader.FadeIn(fadeInTime);

            // Trigger new scene loaded event
            GameEvents.TriggerNewSceneLoaded();
        }
    }
}