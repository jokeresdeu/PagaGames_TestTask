using UnityEngine;
using Zenject;

public class ActionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IShooter>().To<Shooter>().AsSingle();
    }
}