using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateController : ArcherStateController  
{
    
    #region Params
   
    PlayerStats playerStats;
    Mover mover;
    InputController inputController;
    Vector3 lookAt;
    #endregion 
    
    protected override void Start()
    {
        base.Start();
        playerStats = GetComponent<PlayerStats>();
        mover = GetComponentInChildren<Mover>();
        inputController = GetComponentInChildren<InputController>();
    }
    void GetNewTarget()
    {
        float distanse=0;
        float temp=0;
        for (int i = 0; i < targetGiver.Enemies.Count; i++)
        {
            if (targetGiver.Enemies[i] != null)
            {
                if (distanse == 0)
                    distanse = Vector3.Distance(transform.position, targetGiver.Enemies[i].transform.position);
                temp = Vector3.Distance(transform.position, targetGiver.Enemies[i].transform.position);
                if (distanse >= temp)
                {
                    distanse = temp;
                    target = targetGiver.Enemies[i];
                }
            }
                
           
        }

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        mover.Move(inputController.Direction, playerStats.Speed);
        ChooseState();
    }
    protected void  ChooseState()
    {
        if (inputController.Direction != Vector3.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            if(!animator.GetBool("Shoot"))
                GetNewTarget();
            animator.SetBool("Run", false);
            if (target != null)
            {
                animator.SetBool("Shoot", true);
                lookAt.x = target.transform.position.x;
                lookAt.y = transform.position.y;
                lookAt.z = target.transform.position.z;
                mover.transform.LookAt(lookAt);
            }
            else
            {
                GetNewTarget();
                animator.SetBool("Shoot", false);
            }
        }
    }
    public override void Atack()
    {
        if (target != null)
             shooter.SetAmmoAndShoot(1, target.transform, muzzle, playerStats.AmmoDamage, playerStats.AmmoSpeed, material, layer);
    }
    public class Factory : PlaceholderFactory<PlayerStateController> { }
}
