using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    [Header("Sound Effects")]
    [SerializeField] public AudioSource ouch;
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage - resistance;
        ouch.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
