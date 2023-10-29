using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Essential Game Objects")]
    [SerializeField] public Base playerBase;
    [SerializeField] public Sprite playerBaseSprite1;
    [SerializeField] public Sprite playerBaseSprite2;
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
    public static int stageNumber = 1;
    private bool roundEnded = false;
    private bool roundStarted = false;
    // public GameObject stage1;
    // public GameObject stage2;
    private int rounds = 1;
    //Try to implement background switching
    // public void Awake(){

    //     Debug.Log(GameManager.stageNumber);
    //     stage1 = GameObject.Find("BG1");
    //     stage2 = GameObject.Find("BG2");
    //     if(GameManager.stageNumber == 2){
    //         stage1.SetActive(false);
    //         stage2.SetActive(true);
    //     }
    //     if(GameManager.stageNumber == 1){
    //         stage2.SetActive(false);
    //         stage1.SetActive(true);
    //     }
    // }
    public void Start()
    {
        switch (GameManager.stageNumber)
        {
            case 1:
                defaultRoundTimer = roundTimer;
                break;
            case 2:
                defaultRoundTimer = roundTimer * 1.5f;
                break;
            case 3:
                defaultRoundTimer = roundTimer * 2f;
                break;
        }

    }

    public void Update()
    {
        if (playerBase == null)
        {
            GameOver();
        }
        if (rounds == 5)
        {
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
    public void advanceToNextStage()
    {
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
    public int getCoins()
    {
        return GameManager.coins;
    }
    public void removeCoins(int amount)
    {
        GameManager.coins -= amount;
    }
}
