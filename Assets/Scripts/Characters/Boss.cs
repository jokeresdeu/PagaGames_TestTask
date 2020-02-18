using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : RangedCharacter
{
    public void DealDamage(IDamageTaker taker)
    {
        taker.TakeDamage(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
