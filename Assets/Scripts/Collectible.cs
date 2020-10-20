using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    public CollectibleType collectibleType;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collector collector = collision.GetComponent<Collector>();
        if(collector)
        {
            collector.Collect(collectibleType);
            Destroy(gameObject);
        }
    }
}
