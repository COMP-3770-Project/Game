using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Base playerBase;

    [Header("Heart Settings")]
    [SerializeField] public int numOfHearts;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite fullHeart;
    [SerializeField] public Sprite halfHeart;
    [SerializeField] public Sprite emptyHeart;

    private int maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    public void Start()
    {
        maxHealth = playerBase.maxHealth;
        currentHealth = maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (playerBase != null)
        {
            if (playerBase.currentHealth < currentHealth)
            {
                currentHealth = playerBase.currentHealth;

                // This checks whether or not to set it to an empty heart.
                if (currentHealth % 10 == 0)
                {
                    hearts[currentHealth / 10].sprite = emptyHeart;
                }

                // This checks whether or not to set it to a half heart.
                if (currentHealth % 10 == 5)
                {
                    // Rounds it down to the nearest 10th for an index.
                    int heart = (int)Mathf.Round(currentHealth / 10);
                    hearts[heart].sprite = halfHeart;
                }

                // This loop is to fix the issue of hearts being skipped due to excessive base damage.
                int currentHeart = (int)Mathf.Round(currentHealth / 10);

                for (int i = 0; i < hearts.Length; i++)
                {
                    if (i > currentHeart)
                    {
                        if (hearts[i].sprite != emptyHeart)
                        {
                            hearts[i].sprite = emptyHeart;
                        }
                    }
                }
            }

        }
        else
        {
            hearts[0].sprite = emptyHeart;
        }
    }
}
