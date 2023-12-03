using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public Transform firePoint;

    [Header("Weapon Statistics")]
    [SerializeField] public float fireRate;
    [SerializeField] public int damage;
    [SerializeField] public int magSize = 10;
    [SerializeField] public float reloadSpeed;

    [Header("Weapon Aesthetics")]
    [SerializeField] public static string currentWeapon = "Pistol";
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public List<Sprite> weapons;
    [SerializeField] public AudioSource firingEffect;
    [SerializeField] public AudioSource reloadSound;

    // You set these values for the weapons and they increase each level.
    [Header("Weapon Upgrades")]
    [SerializeField] public int maxLevel;
    [SerializeField] public float fireRateUpgrade;
    [SerializeField] public int damageUpgrade;
    [SerializeField] public int magSizeUpgrade;
    [SerializeField] public float reloadSpeedUpgrade;
    public static int bulletsLeft;
    private bool isShooting;
    private void Awake()
    {
        bulletsLeft = magSize;

        //Laser AR
        if (UpgradeManager.upgradesOwned.Contains(1))
        {
            GetComponent<SpriteRenderer>().sprite = weapons[1];
            currentWeapon = "AR";
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());

        }
        if (Input.GetMouseButtonDown(0) && canShoot())
        {
            isShooting = true;
            StartCoroutine(Shoot());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            StopCoroutine(Shoot());
        }
    }

    private bool canShoot()
    {
        return !isShooting && bulletsLeft > 0;
    }

    private IEnumerator Shoot()
    {
        while (isShooting && bulletsLeft > 0)
        {
            firingEffect.Play();
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().SetDamage(damage);
            bulletsLeft--;
            yield return new WaitForSeconds(1.0f / fireRate);
        }
    }

    private IEnumerator Reload()
    {
        reloadSound.Play();
        yield return new WaitForSeconds(1.0f / reloadSpeed);
        bulletsLeft = magSize;
    }
}