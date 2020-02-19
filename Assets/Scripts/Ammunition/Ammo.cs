using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ammo : MonoBehaviour
{ 
    #region DI
    public class Factory : PlaceholderFactory<Ammo> { }
    IAmmoTaker ammoTaker;
    [Inject]
    public void Contstruct(IAmmoTaker ammoTaker)
    {
        this.ammoTaker = ammoTaker;
    }
    #endregion

    #region Params

    [SerializeField] Rigidbody rb;
    float damage; 
    #endregion

    

    private void OnTriggerEnter(Collider other)
    {
        IDamageTaker damageTaker = other.GetComponent<IDamageTaker>();
        if (damageTaker != null)
        {
            damageTaker.TakeDamage(damage);
        }
        ammoTaker.RetutrnToPool(this);
    }
    


}
