using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    [Header("Enemy Settings")]
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float damage = 1.0f;
    private GameObject playerBase;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GameObject.Find("Base");
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > playerBase.transform.position.x) { 
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, playerBase.transform.position, speed * Time.deltaTime);
    }
}
