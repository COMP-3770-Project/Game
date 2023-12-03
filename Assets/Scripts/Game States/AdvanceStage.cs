using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AdvanceStage : MonoBehaviour
{
    [Header("Advance Next Stage Screen Settings")]
    [SerializeField] public TextMeshProUGUI coinCounter;

    public void Setup(int coins)
    {
        coinCounter.text = coins.ToString();
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        GameManager.stageNumber++;
        //End Of Round Coin Bonus
        switch (GameManager.stageNumber)
        {
            case 1:
                GameManager.coins += 100;
                break;
            case 2:
                GameManager.coins += 150;
                break;
            case 3:
                GameManager.coins += 175;
                break;
        }
        SceneManager.LoadScene("UpgradeVan");
    }
}
