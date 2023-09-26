using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : Damageable
{
    [Header("Base Settings")]
    [SerializeField] public TextMeshProUGUI integrity;

    void Update()
    {
        integrity.text = (getHealth()).ToString();
    }
    public override void Die()
    {
        Destroy(gameObject);
        Debug.Log("Game Over Man");
    }
}
