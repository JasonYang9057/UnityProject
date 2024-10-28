using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewProject.Attribute
{
    /// <summary>
    /// ScriptableObject for defining enemy attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewEnemyAttributes", menuName = "ScriptableObjects/EnemyAttributes")]
    public class EnemyAttributes : ScriptableObject, IEnemyAttributes
    {
        [SerializeField] private float moveSpeed;     // Movement speed of the enemy.
        [SerializeField] private float maxHealth;     // Maximum health of the enemy.
        [SerializeField] private float attackRange;   // Range within which the enemy can attack.
        [SerializeField] private float attackDamage;  // Damage dealt by the enemy.
        [SerializeField] private float attackSpeed;   // Speed at which the enemy attacks.

        public float MoveSpeed => moveSpeed;
        public float MaxHealth => maxHealth;
        public float AttackRange => attackRange;
        public float AttackDamage => attackDamage;
        public float AttackSpeed => attackSpeed;
    }
}