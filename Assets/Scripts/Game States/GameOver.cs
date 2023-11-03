using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [Header("Game Over Screen Settings")]
    [SerializeField] public TextMeshProUGUI roundCounter;
    [SerializeField] public TextMeshProUGUI coinCounter;

    public void Setup(int rounds, int coins)
    {
        roundCounter.text = "Rounds Played: " + rounds.ToString();
        coinCounter.text = coins.ToString();
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameLevel");
    }

}
