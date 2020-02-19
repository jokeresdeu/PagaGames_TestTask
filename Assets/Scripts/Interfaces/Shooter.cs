using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shooter : IShooter
{
    public IAmmoGiver ammoGiver { get ; set ; }

    [Inject]
    public void Construct(IAmmoGiver ammoGiver)
    {
        this.ammoGiver = ammoGiver;
    }
    public void SetAmmoAndShoot(int amount, Transform target, Transform muzzle, float damage, float speed, Material material, int layer)
    {
        for(int i=0; i<amount; i++)
        {
            Ammo temp = ammoGiver.GiveAmmo();
            temp.transform.position = muzzle.position;
            temp.gameObject.layer = layer;
            temp.GetComponent<MeshRenderer>().material = material;
            temp.GetComponent<Rigidbody>().velocity = temp.transform.forward * speed;
            temp.transform.LookAt(target);
            temp.gameObject.SetActive(true);
        }
    }
}
