using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArcherStats<T> : CharacterStats<T> where T : SavedArcherStats 
{
    [SerializeField]protected float ammoSpeed;
    public float AmmoSpeed { get { return ammoSpeed; } }
    [SerializeField]protected float ammoDamage;
    public float AmmoDamage { get { return ammoDamage; } }
    public  override void SetStats(T stats)
    {
        base.SetStats(stats);
        ammoSpeed = stats.ammoSpeed;
        ammoDamage = stats.ammoDamage;
    }
    public virtual void ChangeAmoSpeed(float amSpeedBoost)
    {
        ammoSpeed *= amSpeedBoost;
    }
    public virtual void ChangeAmmoDamage(float amDamageBoost)
    {
        ammoDamage *= amDamageBoost;
    }
}
