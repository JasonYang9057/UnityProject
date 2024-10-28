using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.SceneTransition
{
    /// <summary>
    /// Manages fade-in and fade-out effects for a UI Canvas using a CanvasGroup.
    /// </summary>
    public class ScreenFader : MonoBehaviour, IScreenFader
    {
        [SerializeField] CanvasGroup canvasGroup; // The CanvasGroup component used for fading effects
        Coroutine currentActiveFade = null; // Reference to the currently active fade coroutine

        /// <summary>
        /// Fades in the screen over a specified duration.
        /// </summary>
        /// <param name="time">Duration of the fade-in effect.</param>
        /// <returns>The Coroutine for the fade operation.</returns>
        public Coroutine FadeIn(float time)
        {
            return Fade(0, time);
        }

        /// <summary>
        /// Fades out the screen over a specified duration.
        /// </summary>
        /// <param name="time">Duration of the fade-out effect.</param>
        /// <returns>The Coroutine for the fade operation.</returns>
        public Coroutine FadeOut(float time)
        {
            return Fade(1, time);
        }

        /// <summary>
        /// Initiates a fade to the specified target alpha value over a given duration.
        /// </summary>
        /// <param name="target">Target alpha value (0 for transparent, 1 for opaque).</param>
        /// <param name="time">Duration of the fade effect.</param>
        /// <returns>The Coroutine for the fade operation.</returns>
        public Coroutine Fade(float target, float time)
        {
            if (currentActiveFade != null)
            {
                StopCoroutine(currentActiveFade);
            }
            currentActiveFade = StartCoroutine(FadeRoutine(target, time));
            return currentActiveFade;
        }

        /// <summary>
        /// Coroutine that handles the fading process to the target alpha value.
        /// </summary>
        /// <param name="target">Target alpha value.</param>
        /// <param name="time">Duration of the fade effect.</param>
        /// <returns>IEnumerator for coroutine.</returns>
        private IEnumerator FadeRoutine(float target, float time)
        {
            while (!Mathf.Approximately(canvasGroup.alpha, target))
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.unscaledDeltaTime / time);
                yield return null;
            }
        }
    }
}