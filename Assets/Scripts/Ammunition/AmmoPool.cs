using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AmmoPool : IAmmoGiver, IAmmoTaker
{
    [Inject]
    Ammo.Factory ammoFactory;// Start is called before the first frame update

    List<Ammo> ammoSet = new List<Ammo>();
   

    public Ammo GiveAmmo()
    {
        if (ammoSet.Count == 0)
            CreateAmmo();
        Ammo temp = ammoSet[0];
        ammoSet.RemoveAt(0);
        
        return temp;
    }
    void CreateAmmo()
    {
        Ammo temp = ammoFactory.Create();
        ammoSet.Add(temp);
    }

    public void RetutrnToPool(Ammo ammo)
    {
        ammoSet.Add(ammo);
        ammo.gameObject.SetActive(false);
    }
}
