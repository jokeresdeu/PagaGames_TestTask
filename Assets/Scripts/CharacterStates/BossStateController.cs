using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class BossStateController : ArcherStateController
{
    DamageDealer damageDealer;
    BossStats bossStats;
    NavMeshAgent meshAgent;
    Vector3 destenation;
    bool needToMove;
    float timer;
    int shootCounter;
    IDamageTaker player;
    protected override void Start()
    {
        base.Start();
        damageDealer = GetComponentInChildren<DamageDealer>();
        bossStats = GetComponent<BossStats>();
        meshAgent = GetComponentInChildren<NavMeshAgent>();
        target = targetGiver.Player;
        meshAgent.speed = 2 * bossStats.Speed;
    }
   public void ChooseState()
   {
        if(target!=null)
        {
            int state = Random.Range(0, 4);
            animator.SetInteger("State", state);
        }
        
   }
    public void RetunrToDefaultState()
    {
        needToMove = false;
        animator.SetInteger("State", 0);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (target == null)
            return;
        if(needToMove)
        {
            meshAgent.destination = destenation;
            meshAgent.speed = 2 * bossStats.Speed;
        }
        else
        {
            meshAgent.speed = 0;
            damageDealer.transform.LookAt(target.transform);
        }
        player = damageDealer.CanAtack();
        if (player != null && timer <= 0)
            Atack();
        
    }
    public void Move()
    {
        Debug.Log("Move");
        destenation = target.transform.position;
        needToMove = true;
        meshAgent.isStopped = false;
    }
    public void ShootDegre()
    {
        Debug.Log("ShootDegre");
        shooter.SetAmmoAndShoot(3, target.transform, muzzle, bossStats.AmmoDamage, bossStats.AmmoSpeed, material, layer);
    }
    public void ShootLine()
    {
        Debug.Log("ShootLine");
        shooter.SetAmmoAndShoot(1, target.transform, muzzle, bossStats.AmmoDamage, bossStats.AmmoSpeed, material, layer);
        shootCounter++;
        if (shootCounter <= 2)
        {
            Invoke("ShootLine", 0.2f);
        }
        else shootCounter = 0;
    }
    public override void Atack()
    {
        player.TakeDamage(bossStats.Damage);
        needToMove = false;
        timer = 1 / bossStats.AtackSpeed;
        meshAgent.velocity = Vector3.zero;
        meshAgent.isStopped = true;
    }
    public class Factory : PlaceholderFactory<BossStateController> { }
}
