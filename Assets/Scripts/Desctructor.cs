using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Desctructor : MonoBehaviour
{
    public int damage = 1;
    public DestructibleType type;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger) return;
        Destructible destructible = collider.gameObject.GetComponent<Destructible>();
        InflictDamage(destructible);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.isTrigger) return;
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        InflictDamage(destructible);
    }

    private void InflictDamage(Destructible destructible)
    {
        if (destructible && destructible.type == type)
        {
            destructible.TakeDamage(damage);
        }
    }

}
