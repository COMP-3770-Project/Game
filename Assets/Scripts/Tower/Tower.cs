using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Settings")]
    [SerializeField] public int damage = 1;
    [SerializeField] public float fireRate = 1.0f;
    [SerializeField] public string soundName;
    [SerializeField] public int cost = 100;

    [Header("Attribute")]
    [SerializeField] public float range = 1.0f;

    private Collider2D target;
    private GameObject playerBase;
    private bool flipped = false;

    private Coroutine firing;
    private AudioSource firingSound;
    LayerMask enemy;
    public void Start()
    {
        enemy = LayerMask.GetMask("Enemy");
        playerBase = GameObject.Find("Base");
        firingSound = GameObject.Find(soundName).GetComponent<AudioSource>();
        // This flips the orientation of the tower opposite to the direction of the base.
        if (transform.position.x < playerBase.transform.position.x && !flipped)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            flipped = true;
        }
    }

    void Update()
    {
        if (FindTargets() && firing == null)
        {
            Debug.Log("Found targets");
            firing = StartCoroutine(Attack());
        }

        if (!FindTargets() && firing != null)
        {
            StopCoroutine(firing);
            firing = null;
        }

    }

    private bool FindTargets()
    {
        // An invisible circle is created and if an enemy goes inside the circle they get targetted.
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2)transform.position, 0f, enemy);
        Debug.Log(hits.Length);
        if (hits.Length > 0)
        {

            target = hits[0].collider;
            return true;
        }
        else
        {
            target = null;
        }

        return false;
    }

    private IEnumerator Attack()
    {
        while (FindTargets())
        {
            yield return new WaitForSeconds(1 / fireRate);
            if (target != null)
            {
                firingSound.Play();
                target.GetComponent<Damageable>().TakeDamage(damage);
            }
        }
    }
}
