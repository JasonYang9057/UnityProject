using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.SceneTransition
{
    /// <summary>
    /// Defines a contract for screen fader to fade in and out
    /// </summary>
    public interface IScreenFader
    {
        /// <summary>
        /// Initiates a fade-in effect over the specified duration.
        /// </summary>
        /// <param name="time">The duration of the fade-in effect in seconds.</param>
        /// <returns>A Coroutine representing the fade-in operation.</returns>
        public Coroutine FadeIn(float time);

        /// <summary>
        /// Initiates a fade-out effect over the specified duration.
        /// </summary>
        /// <param name="time">The duration of the fade-out effect in seconds.</param>
        /// <returns>A Coroutine representing the fade-out operation.</returns>
        public Coroutine FadeOut(float time);
    }
}