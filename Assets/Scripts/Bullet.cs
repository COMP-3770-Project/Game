using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed = 10f;
    public Rigidbody2D rb;
    Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private int damage = 0;
    void Update()
    {
        transform.position = transform.position + (transform.right * speed * Time.deltaTime);

        if (!renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name}");

        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}