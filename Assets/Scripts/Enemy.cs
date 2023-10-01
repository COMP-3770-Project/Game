using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    [Header("Enemy Settings")]
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public int damage = 1;
    [SerializeField] public float range = 0.5f;
    [SerializeField] public float attackCooldown = 0.0f;
    [SerializeField] public int worth = 1;

    private float lastAttackTime;
    private GameObject playerBase;
    private GameManager manager;
    private bool flipped;

    // Since this will be used for a prefab, we cannot take a reference through the editor, 
    // therefore we have to find the game objects.
    public void Start()
    {
        playerBase = GameObject.Find("Base");
        GameObject gm = GameObject.Find("Game Manager");
        manager = gm.GetComponent<GameManager>();
    }

    public void Update()
    {

        if (playerBase != null)
        {
            // This is to make the sprite face towards the base.
            if (transform.position.x > playerBase.transform.position.x && !flipped)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                flipped = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, playerBase.transform.position, speed * Time.deltaTime);

            if (CanHit())
            {
                Attack();
            }
        }
    }

    private bool CanHit()
    {
        // Checks if the enemy is within range of the castle and has no cooldowns available.
        return Vector3.Distance(
            transform.position, playerBase.transform.position) <= range &&
            Time.time - lastAttackTime >= attackCooldown;
    }

    private void Attack()
    {
        if (playerBase != null)
        {
            playerBase.GetComponent<Damageable>().TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }

    public override void Die()
    {
        base.Die();
        manager.addCoins(worth);
    }

    // TO DO: Add logic for upgrading enemies
    public void addHealth(int health)
    {
        maxHealth += health;
    }
}