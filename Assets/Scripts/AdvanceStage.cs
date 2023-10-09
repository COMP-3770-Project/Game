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

    public void Setup(int rounds, int coins)
    {
        coinCounter.text = coins.ToString();
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("UpgradeVan");
    }

}
