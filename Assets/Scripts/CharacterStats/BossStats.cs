using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossStats : ArcherStats
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
    ILoader loader;
    [Inject]
    void Construct(ILoader loader)
    {
        this.loader = loader;
    }
    //protected override void Start()
    //{
    //    Save();
    //}
    //void Save()
    //{
    //    SavedStats savedStats = new SavedStats();
    //    savedStats.characterType = characterType;
    //    loader.Save(savedStats);
    //}
}
