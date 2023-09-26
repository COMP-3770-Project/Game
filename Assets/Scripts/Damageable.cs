using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int resistance = 0;

    private int currentHealth;

    // When the game loads this happens.
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // This is called by the enemy.
    public void TakeDamage(int damage)
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
    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
