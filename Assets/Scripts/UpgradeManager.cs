using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    
     private GameManager manager;
    
    [SerializeField] public TextMeshProUGUI money;
    
    public void Start(){
        GameObject gm = GameObject.Find("Game Manager");
        manager = gm.GetComponent<GameManager>();
        manager.addCoins(100);
    }

    public void Update()
    {
            money.text = manager.coins.ToString();
    }


}
