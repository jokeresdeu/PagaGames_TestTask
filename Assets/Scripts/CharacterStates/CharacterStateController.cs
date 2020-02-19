using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateController : MonoBehaviour 
{
    protected Animator animator;
    protected bool canAtack=true;
    [SerializeField]protected Transform target;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void Atack()
    {

    }
    protected virtual void ChooseState()
    {
      
    }
}
