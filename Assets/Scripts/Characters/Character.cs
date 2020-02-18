using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageTaker
{
    protected float hp;
    [SerializeField]string characterType;
    public string CharacterType { get { return characterType; } }
    protected float currentHp;
    protected float atackSpeed;
    protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected Character target;
    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void SetStartParameters(Characteristics characteristics)
    {
        hp = characteristics.hp;
        currentHp = hp;
        speed = characteristics.movementSpeed;
        atackSpeed = characteristics.atackSpeed;
        damage = characteristics.damage;
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            Death();
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
