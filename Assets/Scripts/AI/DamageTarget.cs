using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public int health = 100;

    public void GetDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log(health);
            if (health <= 0)
            {
                Debug.Log("I am dead");
            }
        }
    }
}
