using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI money;
    Animator ani;
    Animator ani2;
    private int[] costArray = { 150, 200, 150, 300 }; //0: Boots, 1: AR Laser, 2: speed boost, 3: Double Health
    public static List<int> upgradesOwned = new List<int>();

    public void Awake()
    {
        GameObject gm = GameObject.Find("Insuff Funds");
        GameObject gm2 = GameObject.Find("Already Own");
        ani = gm.GetComponent<Animator>();
        ani2 = gm2.GetComponent<Animator>();
        ani.SetBool("insuffFunds", false);
        ani2.SetBool("insuffFunds", false);
    }

    public void Update()
    {
        money.text = (GameManager.coins).ToString();
    }

    // 0 - Double Jump
    // 1 - Laser AR
    public void addUpgrade(int upgrade)
    {
        Debug.Log("Attempting to add upgrade: " + upgrade);

        if (GameManager.coins >= costArray[upgrade] && !upgradesOwned.Contains(upgrade))
        {
            Debug.Log("Upgrade purchase successful. Deducting coins...");
            GameManager.coins -= costArray[upgrade];
            upgradesOwned.Add(upgrade);
            Debug.Log("Upgrade added successfully. New coins: " + GameManager.coins);
        }
        else if (GameManager.coins <= costArray[upgrade] && !upgradesOwned.Contains(upgrade))
        {
            Debug.Log("Insufficient funds!");
            StartCoroutine(insuffPopup());
        }
        else if (upgradesOwned.Contains(upgrade))
        {
            Debug.Log("Already own this upgrade!");
            StartCoroutine(alreadyOwnPopup());
        }
    }

    IEnumerator insuffPopup()
    {
        ani.SetBool("insuffFunds", true);
        yield return new WaitForSeconds(3);
        ani.SetBool("insuffFunds", false);
    }

    IEnumerator alreadyOwnPopup()
    {
        ani2.SetBool("insuffFunds", true);
        yield return new WaitForSeconds(3);
        ani2.SetBool("insuffFunds", false);
    }
}
