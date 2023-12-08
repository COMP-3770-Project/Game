using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    [Header("Sound Effects")]
    [SerializeField] public AudioSource ouch;

    // Reference to the UpgradeManager script
    public UpgradeManager upgradeManager;

    public override void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage + resistance);
        ouch.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Add a method to be called when a new perk or weapon is acquired
    public void ActivateUpgrade(int upgradeType)
    {
        // Implement the logic to activate the upgrade based on the upgradeType
        // For example, you might check upgradeType and enable corresponding features.
        // You can use switch statements or if conditions based on your upgrade types.
        switch (upgradeType)
        {
            case 0:
                // Activate Double Jump
                // Add your logic here
                break;

            case 1:
                // Activate Laser AR
                // Add your logic here
                break;

            // Add more cases for other upgrade types as needed

            default:
                break;
        }
    }
}
