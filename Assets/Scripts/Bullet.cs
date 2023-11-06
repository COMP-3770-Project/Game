using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed = 10f;
    public Rigidbody2D rb;
    Renderer r;
    void Start()
    {
        r = GetComponent<Renderer>();
    }
    void Update()
    {
        transform.position = transform.position + (transform.right * speed * Time.deltaTime);
        if (!r.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name}");

        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(1);
            Destroy(gameObject);
        }

    }
}