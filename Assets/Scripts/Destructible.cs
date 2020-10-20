using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public DestructibleType type;
    public int maxHitPoints = 3;
    [SerializeField]
    private int hitPoints = 0;

    private void Start()
    {
        hitPoints = maxHitPoints;
    }

    public void TakeDamage(int damageAmount)
    {
        ModifyHitPoints(-1 * damageAmount);
    }

    public void HealDamage(int healAmount)
    {
        ModifyHitPoints(healAmount);
    }

    private void ModifyHitPoints(int modAmount)
    {
        hitPoints += modAmount;
        hitPoints = Mathf.Min(maxHitPoints, hitPoints);
        if(hitPoints <= 0 && type == DestructibleType.Environment)
        {
            Destroy(gameObject);
        }
    }

    public bool isDown()
    {
        return hitPoints <= 0;
    }

    public int GetCurrentHitPoints()
    {
        return hitPoints;
    }
}
