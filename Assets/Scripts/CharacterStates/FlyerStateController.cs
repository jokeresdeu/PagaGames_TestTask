using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FlyerStateController : ArcherStateController 
{
    Flying flying;
    bool isMoving;
    FlyerStats flyerStats;
    protected override void Start()
    {
        base.Start();
        flying = GetComponentInChildren<Flying>();
        flyerStats = GetComponent<FlyerStats>();
        target = targetGiver.Player;
        StartMovement();
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            flying.Move(flyerStats.Speed);
        }
        else flying.Move(0);
    }
    public void StartMovement()
    {
        flying.transform.Rotate(0, Random.Range(0, 360), 0);
        isMoving = true;
        animator.SetBool("Atack", false);
        animator.SetBool("Run", true);

    }
    public void StopMovement()
    {
        isMoving = false;
        animator.SetBool("Run", false);
        if (target!=null)
        {
            flying.transform.LookAt(target.transform);
            animator.SetBool("Atack", true);
        }
    }
    public override void Atack()
    {
        shooter.SetAmmoAndShoot(1, target.transform, muzzle, flyerStats.AmmoDamage, flyerStats.AmmoSpeed, material, layer);
    }
    public class Factory: PlaceholderFactory<FlyerStateController> { }
}
