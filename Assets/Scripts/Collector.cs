using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    public List<CollectibleType> collected;

    private void Awake()
    {
        collected = new List<CollectibleType>();
    }

    public void Collect(CollectibleType collectibleType)
    {
        collected.Add(collectibleType);
        if(collectibleType == CollectibleType.Health)
        {
            Destructible destructible = GetComponent<Destructible>();
            if(destructible && destructible.GetCurrentHitPoints() < destructible.maxHitPoints)
            {
                destructible.HealDamage(1);
            }
        }
        GetCollectibleCount(collectibleType);
    }

    public int GetCollectibleCount(CollectibleType collectibleType)
    {
        int numOfType = 0;
        for (int i = 0; i < collected.Count; i++) 
        {
            CollectibleType collectedType = collected[i];
            if(collectedType == collectibleType)
            {
                numOfType++;
            }
        }
        return numOfType;
    }
}
