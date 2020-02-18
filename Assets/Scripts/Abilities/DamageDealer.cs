using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer :MonoBehaviour 
{
    IDamageDealer damageDealer;
    private void Start()
    {
        damageDealer = GetComponent<IDamageDealer>();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if(character!=null&&damageDealer.CanDealDamage)
        {
            character.TakeDamage(damageDealer.Damage);
        }
    }
}
