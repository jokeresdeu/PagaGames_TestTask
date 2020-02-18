using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class RangedCharacter: Character
{
    #region Params
    [Header("ProjectileParams")]
    [SerializeField] Transform muzzle;
    [SerializeField] LayerMask ammoLayer;
    [SerializeField] Color ammoColor;
    [SerializeField] float ammoSpeed;

    #endregion
    #region DI
    IAmmoGiver ammoPool;
    [Inject]
    public void Construct(IAmmoGiver ammoPool)
    {
        this.ammoPool = ammoPool;
    }
    #endregion
    public override void SetStartParameters(Characteristics characteristics)
    {
        base.SetStartParameters(characteristics);
        ammoSpeed = characteristics.ammoSpeed;
    }
    public virtual void Shoot()
    {
        Ammo temp = ammoPool.GiveAmmo();
        temp.transform.position = muzzle.position;
        temp.gameObject.SetActive(true);
        Vector3 ammoDirection = (target.transform.position - muzzle.transform.position).normalized * ammoSpeed;
        temp.SetStartParams(ammoDirection, ammoColor, ammoLayer, damage);
    }
    
}
