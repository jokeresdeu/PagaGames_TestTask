using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface  IShooter 
{
    IAmmoGiver ammoGiver { get;  set; }
  
    //Transform muzzle { get; set; }
    void SetAmmoAndShoot(int amount, Transform target, Transform muzzle, float damage, float speed, Material material, int layer);
}
