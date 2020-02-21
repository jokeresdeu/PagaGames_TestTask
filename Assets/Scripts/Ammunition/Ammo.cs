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
    void Contstruct(IAmmoTaker ammoTaker)
    {
        this.ammoTaker = ammoTaker;
    }
    #endregion

    #region Params

    [SerializeField] Rigidbody rb;
    float damage;
    public float Damage{ set { damage = value; } }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        IDamageTaker damageTaker = other.GetComponentInParent<IDamageTaker>();
        if (damageTaker != null)
        {
            damageTaker.TakeDamage(damage);
        }
        ammoTaker.RetutrnToPool(this);
    }
    


}
