using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

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

    public bool doneDialogue;

    public Scene scene; 
    public void Start()
    {
        doneDialogue = false;

        scene = SceneManager.GetActiveScene();

        if (scene.name == "GameLevel")
        {
            StartCoroutine(StartDialogueStage1());
        } else if (scene.name == "Stage2")
        {
            StartCoroutine(StartDialogueStage2());
        } else if (scene.name == "Stage3")
        {
            StartCoroutine(StartDialogueStage3());
        }

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
        if (doneDialogue)
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

            if (!roundStarted && roundTimer > 0 && doneDialogue)
            {
                foreach (Spawner spawner in spawners)
                {
                    spawner.gameObject.SetActive(true);
                }

                roundStarted = true;
            }

            if (roundTimer <= 0 && playerBase != null && doneDialogue)
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
                if (scene.name == "GameLevel")
                {
                    StartCoroutine(EndDialogueStage1());
                }
                else if (scene.name == "Stage2")
                {
                    StartCoroutine(EndDialogueStage2());
                }
                
                temp++;
            }
            if (!roundEnded) roundTimer -= Time.deltaTime;
        }
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

    public IEnumerator StartDialogueStage1()
    {

        dialogueBox.toggle();

        string text = "Hey John buddy, what's happening down in at the farm?";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(3);

        text = "Did you say your wife just got captured by aliens? Give me time to locate the aircraft and it's positioning";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(3);
        dialogueBox.toggle();

        doneDialogue = true;
        yield return new WaitForFixedUpdate();
    }


    public IEnumerator StartDialogueStage2()
    {

        dialogueBox.toggle();

        string text = "The aliens have hacked my servers!! You'll have to fight these aliens without me";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(3);

        text = "You got this brother!";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(3);
        dialogueBox.toggle();

        doneDialogue = true;
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator StartDialogueStage3()
    {
        dialogueBox.toggle();
        string text = "The weather is looking beautiful isn't it...keep on the lookout for the last rocket part!";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(4);
    }


    public IEnumerator EndDialogueStage1()
    {
        dialogueBox.toggle();
        string text = "The aircraft is headed towards Seattle, get out of there boss!!!";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(5);
    }

    public IEnumerator EndDialogueStage2()
    {
        dialogueBox.toggle();
        string text = "I'm back...";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(2);
        text = "Looks like you're going to Cali, finish off the last of these aliens and head out!";
        dialogueBox.SetDialogueText(text);
        yield return new WaitForSeconds(3);


    }
}
