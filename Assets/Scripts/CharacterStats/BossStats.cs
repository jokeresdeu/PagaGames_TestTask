using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : ArcherStats<SavedArcherStats> 
{
    protected float damage;
    public float Damage { get { return damage; } }
    public override void SetStats(SavedArcherStats stats)
    {
        base.SetStats(stats);
        damage = stats.damage;
    }

    public virtual void ChangeDamage(float damageBoost)
    {
        damage *= damageBoost;
    }
}
