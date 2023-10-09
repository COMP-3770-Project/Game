using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Essential Game Objects")]
    [SerializeField] public Base playerBase;
    [SerializeField] public Spawner[] spawners;
    [SerializeField] public TextMeshProUGUI health;
    [SerializeField] public TextMeshProUGUI money;
    [SerializeField] public TextMeshProUGUI roundTracker;
    [SerializeField] public GameOver gameOver;
    [SerializeField] public AdvanceStage advanceStage;

    [Header("Game Settings")]
    [SerializeField] public float roundTimer;
    public float defaultRoundTimer;
    [SerializeField] public static int coins = 300;
    [SerializeField] public int lastTower = 0;
    [SerializeField] public int spawnOnLeft = 0;

    [SerializeField] public int bonus;

    private bool roundEnded = false;
    private bool roundStarted = false;

    private int rounds = 1;
    public void Start(){
        defaultRoundTimer = roundTimer;
    }

    public void Update()
    {
        if (playerBase == null)
        {
            GameOver();
        }
        if(rounds ==5){
            advanceToNextStage();
        }
        if (playerBase != null)
        {
            money.text = GameManager.coins.ToString();
            roundTracker.text = rounds.ToString();

        }

        if (!roundStarted && roundTimer > 0)
        {
            foreach (Spawner spawner in spawners)
            {
                spawner.gameObject.SetActive(true);
            }

            roundStarted = true;
        }

        if (roundTimer <= 0 && playerBase != null)
        {
            roundEnded = true;
            roundStarted = false;
            foreach (Spawner spawner in spawners)
            {
                spawner.gameObject.SetActive(false);
            }

            rounds++;

            GameManager.coins += bonus * rounds;
            roundTimer = defaultRoundTimer;
            roundEnded = false;
        }

        if (!roundEnded) roundTimer = roundTimer - Time.deltaTime;
    }

    public void GameOver()
    {
        foreach (Spawner spawner in spawners)
        {
            spawner.gameObject.SetActive(false);
        }

        gameOver.Setup(rounds, GameManager.coins);
    }
    public void advanceToNextStage(){
        foreach (Spawner spawner in spawners)
        {
            spawner.gameObject.SetActive(false);
        }
        
        advanceStage.Setup(GameManager.coins);
    }

    public void addCoins(int amount)
    {
        GameManager.coins += amount;
    }
    public int getCoins(){
        return GameManager.coins;
    }
    public void removeCoins(int amount){
        GameManager.coins -= amount;
    }
}
