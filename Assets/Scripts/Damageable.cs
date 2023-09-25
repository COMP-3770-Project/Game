using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float resistance = 0f;

    private float currentHealth;

    // When the game loads this happens.
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // This is called by the enemy.
    public void TakeDamage(float damage)
    {
        if (resistance < damage)
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // This is abstract because we want each effect to be different.
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
