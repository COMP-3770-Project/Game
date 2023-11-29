using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    private GameManager manager;

    [SerializeField] public GameObject[] towerTypes;
    public void Start()
    {
        GameObject gm = GameObject.Find("Game Manager");
        manager = gm.GetComponent<GameManager>();
    }
    public void spawnTower(int towerId)
    {
        GameObject towerToSpawn = towerTypes[towerId];
        GameObject player = GameObject.Find("Player"); // replace "Player" with your player's name
        Vector3 playerPosition = player.transform.position;

        // Check the direction the player is facing by looking at the rotation
        Vector3 spawnDirection = player.transform.rotation.y < 0 ? Vector3.right : Vector3.left;
        Vector3 spawnPosition = playerPosition + spawnDirection; // spawn the tower in the direction the player is facing

        // replace y with the ground level if needed
        spawnPosition.y = 0.3f;
        spawnPosition.z = 0f;

        if (GameManager.coins >= 100)
        {
            // Rotate the cannon by 180 degrees if the player is facing left
            Quaternion spawnRotation = player.transform.rotation.y < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            Instantiate(towerToSpawn, spawnPosition, spawnRotation);
            manager.removeCoins(100);
        }
    }
}
