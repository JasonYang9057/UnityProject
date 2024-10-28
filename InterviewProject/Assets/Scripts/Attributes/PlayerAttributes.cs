using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Attribute
{
    /// <summary>
    /// ScriptableObject for defining enemy attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewPlayerAttributes", menuName = "ScriptableObjects/PlayerAttributes")]
    public class PlayerAttributes : ScriptableObject, IPlayerAttributes
    {
        [SerializeField] private float moveSpeed; // Movement speed of the player.
        [SerializeField] private float jumpSpeed; // Jump speed of character
        [SerializeField] private float gravity; // Gravity affecting the player.
        [SerializeField] private float groundCheckRadius; // Radius for ground detection.
        [SerializeField] private float maxHealth; // Maximum health of the player.
        [SerializeField] private float regenerationTime; // Time taken for health regeneration.
        [SerializeField] private float regenerationAmount; // Amount of health regenerated.
        [SerializeField] private float attackDamage; // Damage dealt by the player.
        [SerializeField] private float attackSpeed; // Speed at which the player attacks.
        [SerializeField] private float mouseSensitiveX; // Mouse sensitivity on the X-axis.
        [SerializeField] private float mouseSensitiveY; // Mouse sensitivity on the Y-axis.

        public float MoveSpeed => moveSpeed;
        public float JumpSpeed => jumpSpeed;
        public float Gravity => gravity;
        public float GroundCheckRadius => groundCheckRadius;
        public float MaxHealth => maxHealth;
        public float RegenerationTime => regenerationTime;
        public float RegeneraitonAmount => regenerationAmount;
        public float AttackDamage => attackDamage;
        public float AttackSpeed => attackSpeed;
        public float MouseSensitiveX => mouseSensitiveX;
        public float MouseSensitiveY => mouseSensitiveY;
    }
}