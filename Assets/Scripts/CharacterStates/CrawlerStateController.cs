using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        navMeshAgent = GetComponent<NavMeshAgent>();
        damageDealer = GetComponent<DamageDealer>();
        navMeshAgent.speed = crawlerStats.Speed;
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
    protected override void ChooseState()
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
        player.TakeDamage(crawlerStats.Damage);
    }
}
