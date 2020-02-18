using System.Collections;
using System.Collections.Generic;

public interface IDamageDealer 
{
    int Damage { get; set; }
    bool CanDealDamage { get; set; }
}
