using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Damageable
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
