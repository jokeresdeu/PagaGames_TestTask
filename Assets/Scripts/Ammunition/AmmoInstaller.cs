using UnityEngine;
using Zenject;

public class AmmoInstaller : MonoInstaller
{
    public GameObject ammoPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<Ammo>().AsSingle();
        Container.BindFactory<Ammo, Ammo.Factory>().FromComponentInNewPrefab(ammoPrefab);
        //Container.Bind<IAmmoGiver>().To<AmmoPool>().AsCached();
        Container.BindInterfacesAndSelfTo<AmmoPool>().AsSingle();
        //Container.Bind<IAmmoTaker>().To<AmmoPool>().AsCached();
    }
}