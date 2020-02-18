using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Character, IDamageDealer 
{
    public int Damage { get ; set ; }
    public bool CanDealDamage { get ; set ; }

   
    void Update()
    {
        
    }
}
