using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPOS;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>2){
            timer = 0;
            shoot();
        }
    }
    void shoot(){
        Instantiate(bullet, bulletPOS.position, Quaternion.identity);
    }
}
