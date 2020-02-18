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
    [SerializeField] Material material;
    LayerMask layerToIgnore;
    float damage; 
    #endregion

    public void SetStartParams(Vector3 direction, Color color, LayerMask layer, float damage)
    {
        rb.velocity = direction;
        material.color = color;
        this.damage = damage;
      
    }
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
