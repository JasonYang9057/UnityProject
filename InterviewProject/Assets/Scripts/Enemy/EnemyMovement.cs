using InterviewProject.Attribute;
using InterviewProject.Mechanic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace InterviewProject.TheEnemy
{
    /// <summary>
    /// Manages enemy movement using a NavMeshAgent.
    /// </summary>
    public class EnemyMovement : MonoBehaviour, IMovement, IStopAgent
    {
        [SerializeField] NavMeshAgent agent; // NavMesh agent for pathfinding.

        private float moveSpeed; // Movement speed of the enemy.
        private float stopSpeed = 0.01f; // Speed when stopping the agent. Not set to 0 for collision detection.

        /// <summary>
        /// Sets the movement attributes for the enemy.
        /// </summary>
        /// <param name="attributes">Attributes containing movement speed.</param>
        public void SetAttributes(IAttributes attributes)
        {
            // Assign speed to the NavMesh agent.
            moveSpeed = attributes.MoveSpeed;
            agent.speed = moveSpeed;
        }

        /// <summary>
        /// Moves the enemy to the specified target position.
        /// </summary>
        /// <param name="target">Target position to move towards.</param>
        public void MoveTo(Vector3 destination)
        {
            // Move Navmesh agent to the destination.
            agent.speed = moveSpeed;
            agent.SetDestination(destination);
        }

        /// <summary>
        /// Stops the enemy's movement by reducing the agent's speed.
        /// </summary>
        public void StopAgent()
        {
            // Stop Navmesh agent
            agent.speed = stopSpeed;
        }
    }
}