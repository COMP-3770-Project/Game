using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPrefab;
    GameObject bullet;
    public AudioSource soundEffect;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            soundEffect.Play();
            Shoot();
        }
        
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}