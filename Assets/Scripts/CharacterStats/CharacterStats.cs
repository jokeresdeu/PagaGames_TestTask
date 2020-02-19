using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterStats<T> : MonoBehaviour, IDamageTaker where T:SavedStats  
{
    [SerializeField] Slider hpBar;
    [SerializeField]protected int hp;

    protected int currentHP;
    public float CurrentHp { get { return currentHP; } }
    [SerializeField] protected float speed;
    public float Speed { get { return speed; } }
     protected float atackSpeed;
    public float AtackSpeed { get { return atackSpeed; } }
    public virtual void SetStats(T stats)
    {
        hp = stats.hp;
        currentHP = hp;
        speed = stats.movementSpeed;
        atackSpeed = stats.atackSpeed;
        hpBar.maxValue = hp;
        hpBar.value = currentHP;
    }
    protected virtual void Start()
    {
        currentHP = hp;
        hpBar.maxValue = hp;
        hpBar.value = currentHP;
    }


    public void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= (int)damage;
        hpBar.value = currentHP;
        Debug.Log("Here");
        if (currentHP<= 0)
            Death();
    }
    public virtual void ChageAtackSpeed(float asBoost)
    {
        atackSpeed *= asBoost;
    }
    public virtual void ChangeHp(int hpBoost)
    {
        hp += hpBoost;
    }
    public virtual void ChangeSpeed(float speedBoost)
    {
        speed *= speedBoost;
    }
    public virtual void Heal(int healedHP)
    {
        currentHP += healedHP;
        if (currentHP > hp)
            currentHP = hp;
        hpBar.value = currentHP;
    }
}
