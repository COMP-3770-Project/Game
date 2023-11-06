using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int resistance = 0;

    [SerializeField] public int currentHealth;

    // When the game loads this happens.
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // This is abstract because we can change how the logic works.
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage - resistance;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    // This is abstract because we want each effect to be different.
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
