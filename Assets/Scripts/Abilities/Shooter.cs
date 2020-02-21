using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shooter : IShooter
{
    public IAmmoGiver ammoGiver { get ; set ; }

    [Inject]
    void Construct(IAmmoGiver ammoGiver)
    {
        this.ammoGiver = ammoGiver;
    }
    public void SetAmmoAndShoot(int amount, Transform target, Transform muzzle, float damage, float speed, Material material, int layer)
    {
        int counter = 1;
        for(int i=0; i<amount; i++)
        {
            counter *= -1;
            Ammo temp = ammoGiver.GiveAmmo();
            temp.transform.position = muzzle.position;
            temp.gameObject.layer = layer;
            temp.Damage = damage;
            temp.transform.LookAt(target);
            temp.transform.Rotate(0, (i+1) / 2 * 30 * counter, 0);
            temp.GetComponent<MeshRenderer>().material = material;
            temp.GetComponent<Rigidbody>().velocity = temp.transform.forward * speed;
            temp.gameObject.SetActive(true);
        }
    }
}
