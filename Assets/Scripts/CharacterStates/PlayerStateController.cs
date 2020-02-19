using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateController : CharacterStateController 
{
    IShooter shooter;
    [Inject]
    public void Construct(IShooter shooter)
    {
        this.shooter = shooter;
    }
    #region Params
    [Header("Shooter")]
    [SerializeField] Material material;
    [SerializeField] int layer;
    [SerializeField] Transform muzzle;
    PlayerStats playerStats;
    Mover mover;
    InputController inputController;
    #endregion 
    public bool CanAtack { get { return canAtack; } set { canAtack = value; } }
    protected override void Start()
    {
        base.Start();
        playerStats = GetComponent<PlayerStats>();
        mover = GetComponent<Mover>();
        inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        mover.Move(inputController.Direction, playerStats.Speed);
        ChooseState();
    }
    protected override void  ChooseState()
    {
        if (inputController.Direction != Vector3.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
            if (target != null)
            {
                animator.SetBool("Shoot", true);
                transform.LookAt(target);
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
        }
    }
    public override void Atack()
    {
        shooter.SetAmmoAndShoot(1, target, muzzle, playerStats.AmmoDamage, playerStats.AmmoSpeed, material, layer);
    }
}
