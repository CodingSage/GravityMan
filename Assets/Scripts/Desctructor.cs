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
        Destructible destructible = collider.gameObject.GetComponent<Destructible>();
        if (destructible == null || collider.isTrigger && destructible.type != DestructibleType.Environment) return;
        InflictDamage(destructible);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        if (destructible == null || collision.collider.isTrigger && destructible.type != DestructibleType.Environment) return;
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
