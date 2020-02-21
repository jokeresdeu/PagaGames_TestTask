using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleCharacterStats : CharacterStats
{
    protected float damage;
    public float Damage { get { return damage; } }
    public override void SetStats(SavedStats stats)
    {
        base.SetStats(stats);
        damage = stats.damage;
    }

    public virtual void ChangeDamage(float damageBoost)
    {
        damage *= damageBoost;
    }
}
