using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ArcherStateController : CharacterStateController
{
    protected IShooter shooter;
    [Inject]
    void Construct(IShooter shooter)
    {
        this.shooter = shooter;
    }

   
  
    [Header("Shooter")]
    [SerializeField] protected Material material;
    [SerializeField] protected int layer;
    [SerializeField] protected Transform muzzle;
  
}
