using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Spawner Settings")]
    [SerializeField] public float spawnRate = 1.0f;
    [SerializeField] public int enemyCount = 1;

    // The enemy types the spawner spawns.
    [SerializeField] public GameObject[] enemies;

    private bool canSpawn = false;
    private Coroutine spawning;

    public void OnEnable()
    {
        canSpawn = true;
        spawning = StartCoroutine(Spawn());
    }

    public void OnDisable()
    {
        canSpawn = false;
        if (spawning != null) StopCoroutine(spawning);
    }

    private IEnumerator Spawn()
    {
        while (canSpawn)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int choice = Random.Range(0, enemies.Length);
                GameObject enemy = enemies[choice];
                Instantiate(enemy, transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
