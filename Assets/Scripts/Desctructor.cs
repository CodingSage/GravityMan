using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Desctructor : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        InflictDamage(destructible);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        InflictDamage(destructible);
    }

    private void InflictDamage(Destructible destructible)
    {
        if (destructible)
        {
            destructible.TakeDamage(damage);
        }
    }

}
