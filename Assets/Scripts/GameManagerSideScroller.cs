using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class GameManagerSideScroller : MonoBehaviour
{
    [Header("Essential Game Objects")]
    [SerializeField] public TextMeshProUGUI health;
    [SerializeField] public TextMeshProUGUI money;
    [SerializeField] public TextMeshProUGUI ammoTracker;
    [SerializeField] public Player player;

    [Header("Game Settings")]
    public float defaultRoundTimer;
    [SerializeField] public static int coins = 300;

    [SerializeField] public int bonus;
    public static GameObject Gate;
    public void Start()
    {
        Gate = GameObject.Find("GateOpen");
        Gate.SetActive(false);
        GameManagerSideScroller.coins = prevCoins();

    }

    public void Update()
    {


        if (player != null)
        {
            money.text = GameManager.coins.ToString();
            ammoTracker.text = Weapon.bulletsLeft.ToString();
        }

    }
    
    public void Respawn()
    {

        //gameOver.Setup(rounds, GameManager.coins);
        Debug.Log("Respawn");

    }
    public int prevCoins(){
        return GameManagerSideScroller.coins;
    }
    public void addCoins(int amount)
    {
        GameManagerSideScroller.coins += amount;
    }
    public int getCoins()
    {
        return GameManagerSideScroller.coins;
    }
    public void removeCoins(int amount)
    {
        GameManagerSideScroller.coins -= amount;
    }
}
