using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public abstract class CharacterStateController : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody target;
    protected ITargetGiver targetGiver;
    [Inject]
    void Construct(ITargetGiver targetGiver)
    {
        this.targetGiver = targetGiver;
    }
    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public virtual void Atack()
    {

    }
}
