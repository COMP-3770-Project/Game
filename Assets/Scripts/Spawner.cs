using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Spawner Settings")]
    [SerializeField] public float spawnRate = 1.0f;
    [SerializeField] public int enemyCount = 1;
    [SerializeField] public GameObject[] enemies;

    private int roundTimer = 120;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    private IEnumerator Spawn()
    {
        while (roundTimer > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int choice = Random.Range(0, enemies.Length);
                GameObject enemy = enemies[choice];
                Instantiate(enemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }

            roundTimer--;
        }
    }
}
