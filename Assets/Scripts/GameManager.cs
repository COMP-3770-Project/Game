using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

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
    [SerializeField] public TextMeshProUGUI ammoTracker;
    [SerializeField] public GameOver gameOver;
    [SerializeField] public AdvanceStage advanceStage;
    [SerializeField] public Player player;
    [SerializeField] public ToggleDialogueBox dialogueBox;

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
    private int rounds = 1;

    private int temp = 0; 

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


        StartCoroutine(StartDialogue());




    }


    public void Update()
    {
        if (playerBase == null || player == null)
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
            ammoTracker.text = Weapon.bulletsLeft.ToString();
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

        if (rounds == 4 && temp == 0)
        {
            StartCoroutine(EndDialogue());
            temp++;
        }
        if (!roundEnded) roundTimer -= Time.deltaTime;
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

    private IEnumerator StartDialogue()
    {

        yield return new WaitForSeconds(4);
        dialogueBox.toggle();

        string text = "Hey John buddy, what's happening down in at the farm?";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(3);

        text = "Did you say your wife just got captured by aliens? Give me time to locate the aircraft and it's positioning";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(5);
        dialogueBox.toggle();
    }

    public IEnumerator EndDialogue()
    {
        dialogueBox.toggle();
        string text = "The aircraft is headed towards Seattle, get out of there boss!!!";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(5);
    }
}
