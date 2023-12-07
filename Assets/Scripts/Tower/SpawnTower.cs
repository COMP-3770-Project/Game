using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public GameManager manager;
    
    [SerializeField] public GameObject[] towerTypes;
    public void Start()
    {
            
    }
    public void spawnTower(int towerId){
        if(manager!=null){
            GameObject towerToSpawn = towerTypes[towerId];
            if(manager.spawnOnLeft==0){manager.lastTower*=-1;manager.lastTower-=3; manager.spawnOnLeft=1;}
            else{manager.lastTower*=-1; manager.spawnOnLeft=0;}
            Vector3 position = new Vector3(manager.lastTower, 0f, 0f);
            if(GameManager.coins >= 100){
            Instantiate(towerToSpawn, position, Quaternion.identity);
            manager.removeCoins(100);
        }

            
        }







    }
}
