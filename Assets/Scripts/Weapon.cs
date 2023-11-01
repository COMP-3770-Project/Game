using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPrefab;
    GameObject bullet;
    public List<Sprite> weapons;
    public AudioSource firingEffect;
    public AudioSource reloadSound;
    public static string currentWeapon="Pistol";
    public static int bulletsLeft = 30;
    void Awake(){
        //Laser AR
        if(UpgradeManager.upgradesOwned.Contains(1)){
            GetComponent<SpriteRenderer>().sprite = weapons[1];
            currentWeapon = "AR";
        }
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(Reload());
            
        }
        if(Input.GetMouseButtonDown(0) && bulletsLeft>0){
            firingEffect.Play();
            Weapon.bulletsLeft--;
            Shoot();
        }
        
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    IEnumerator Reload(){
        reloadSound.Play();
        yield return new WaitForSeconds(1.5f);
        Weapon.bulletsLeft = 30;
    }
}