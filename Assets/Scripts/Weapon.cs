using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPrefab;
    GameObject bullet;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}