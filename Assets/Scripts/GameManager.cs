using UnityEngine;
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
    public void Start()
    {
        switch (GameManager.stageNumber)
        {
            case 1:
                dialogueBox.toggle();
                dialogueBox.SetDialogueText("We are starting round 1, kill the zombies");
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

            string text = "We are starting round " + rounds + ", kill the zombies.";
            dialogueBox.toggle();
            dialogueBox.SetDialogueText(text);
            rounds++;

            GameManager.coins += bonus * rounds;
            roundTimer = defaultRoundTimer;
            roundEnded = false;
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
}
