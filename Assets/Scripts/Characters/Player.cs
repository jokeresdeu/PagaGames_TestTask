using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : RangedCharacter 
{
    #region Params
    InputController controller;
    Mover mover;
    Vector3 direction;
    #endregion 
    override protected void Start()
    {
        base.Start();
        controller = GetComponent<InputController>();
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
        direction.x = controller.Direction.x;
        direction.z = controller.Direction.z;
        direction = direction.normalized;
        ChooseState();

    }

    private void FixedUpdate()
    {
        mover.Move(direction, speed);
    }

    void ChooseState()
    {
        if (direction != Vector3.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
            if (target != null)
            {
                animator.SetBool("Shoot", true);
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
        }
    }
}
