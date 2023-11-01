using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    
    public float speed = 20f;
    public Rigidbody2D rb;
    Renderer r;
    void Start(){
        r = GetComponent<Renderer>();
    }
    void Update(){
        rb.AddForce(transform.right * speed);
        if(!r.isVisible){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 8){
            collision.gameObject.GetComponent<Damageable>().TakeDamage(1);
            Destroy(gameObject);
        }
        
    }
}