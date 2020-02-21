using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStats : ArcherStats
{
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
