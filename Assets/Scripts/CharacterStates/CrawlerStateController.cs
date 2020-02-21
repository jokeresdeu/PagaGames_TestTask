using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class CrawlerStateController : CharacterStateController
{
    [SerializeField] float dUpdateTime;
    DamageDealer damageDealer;
    CrawlerStats crawlerStats;
    NavMeshAgent navMeshAgent;
    IDamageTaker player;
    Vector3 destenation;


    protected override void Start()
    {
        base.Start();
        crawlerStats = GetComponent<CrawlerStats>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        damageDealer = GetComponentInChildren<DamageDealer>();
        navMeshAgent.speed = crawlerStats.Speed;
        target = targetGiver.Player;
        StartCoroutine(GetDestenation());

    }
    IEnumerator GetDestenation()
    {
        if (target != null)
        {
            destenation = target.transform.position;
            yield return new WaitForSeconds(dUpdateTime);
            StartCoroutine(GetDestenation());
        }

    }
    void FixedUpdate()
    {
        ChooseState();
    }
    protected void ChooseState()
    {
        player = damageDealer.CanAtack();
        if (player == null)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Atack", false);
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = destenation;
           
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Atack", true);
            navMeshAgent.isStopped = true;
            navMeshAgent.velocity = Vector3.zero;
           
        }
    }
    public override void Atack()
    {
        if(player!=null)
         player.TakeDamage(crawlerStats.Damage);
    }
    public class Factory : PlaceholderFactory<CrawlerStateController> { }
}
