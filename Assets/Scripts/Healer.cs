using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public int healPoints = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        if (destructible)
        {
            destructible.HealDamage(healPoints);
        }
    }
}
