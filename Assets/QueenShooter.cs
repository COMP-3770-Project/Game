using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueenShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPOS;
    public int queenHealth = 100;
    public Image queenHealthBar;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        queenHealthBar.fillAmount = (float)queenHealth/(float)100;
        timer += Time.deltaTime;
        if(timer>2){
            timer = 0;
            shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.layer==9){
            queenHealth -= 5;
            Destroy(c.gameObject);
        }
    }
    void shoot(){
        Instantiate(bullet, bulletPOS.position, Quaternion.identity);
    }
}
