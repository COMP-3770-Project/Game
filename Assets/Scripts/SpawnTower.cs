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
    public void spawnTower(int towerId){
        
            GameObject towerToSpawn = towerTypes[towerId];
            if(manager.spawnOnLeft==0){manager.lastTower*=-1;manager.lastTower-=3; manager.spawnOnLeft=1;}
            else{manager.lastTower*=-1; manager.spawnOnLeft=0;}
            Vector3 position = new Vector3(manager.lastTower, 0f, 0f);
            if(manager.getCoins() >= 100){
            Instantiate(towerToSpawn, position, Quaternion.identity);
            manager.removeCoins(100);
        }







    }
}
