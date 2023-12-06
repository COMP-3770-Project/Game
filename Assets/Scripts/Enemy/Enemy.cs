using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject player;
    private GameObject playerBaseFloor;
    private GameManagerSideScroller manager;
    private GameManager managerGM;
    private bool flipped;

    // Since this will be used for a prefab, we cannot take a reference through the editor, 
    // therefore we have to find the game objects.
    public void Start()
    {
        playerBaseFloor = GameObject.Find("baseFloor");
        playerBase = GameObject.Find("Base");
        player = GameObject.Find("Player");
        GameObject gm = GameObject.Find("GameManager");
        if(SceneManager.GetActiveScene().name == "FinalLevel"){
            manager = gm.GetComponent<GameManagerSideScroller>();
        }
        else{
            managerGM = gm.GetComponent<GameManager>();
        }
        
    }

    public void Update()
    {

        if (playerBase != null || player != null)
        {
            // This is to make the sprite face towards the base.
            if (transform.position.x > playerBase.transform.position.x && !flipped)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                flipped = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, playerBaseFloor.transform.position, speed * Time.deltaTime);

            if (CanHit())
            {
                Attack();
            }
        }
    }

    private bool CanHit()
    {
        // Checks if the enemy is within range of the castle and has no cooldowns available.
        if (Vector3.Distance(transform.position, playerBase.transform.position) <= range &&
            Time.time - lastAttackTime >= attackCooldown)
        {
            return true;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= range &&
            Time.time - lastAttackTime >= attackCooldown)
        {
            return true;
        }

        return false;
    }

    private void Attack()
    {
        if (playerBase != null && Vector3.Distance(transform.position, playerBase.transform.position) <= range)
        {
            playerBase.GetComponent<Damageable>().TakeDamage(damage);
        }
        else if (player != null && Vector3.Distance(transform.position, player.transform.position) <= range)
        {
            player.GetComponent<Damageable>().TakeDamage(damage);
        }

        lastAttackTime = Time.time;
    }

    public override void Die()
    {
        base.Die();
        if(SceneManager.GetActiveScene().name == "FinalLevel"){
            manager.addCoins(worth);
        }
        else{
            managerGM.addCoins(worth);
        }
        
    }

    // TO DO: Add logic for upgrading enemies
    public void addHealth(int health)
    {
        maxHealth += health;
    }
}
