using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    private GameManager manager;
    
    [SerializeField] public GameObject[] towerTypes;
    public int lastTower = 0;
    public int spawnOnLeft = 0;
    public void Start()
    {
        GameObject gm = GameObject.Find("Game Manager");
        manager = gm.GetComponent<GameManager>();
    }
    public void spawnTower(int towerId){
        
            GameObject towerToSpawn = towerTypes[towerId];
            if(spawnOnLeft==0){lastTower*=-1;lastTower-=3; spawnOnLeft=1;}
            else{lastTower*=-1; spawnOnLeft=0;}
            Vector3 position = new Vector3(lastTower, 0f, 0f);
            if(manager.getCoins() >= 100){
            Instantiate(towerToSpawn, position, Quaternion.identity);
            manager.removeCoins(100);
        }







    }
}
