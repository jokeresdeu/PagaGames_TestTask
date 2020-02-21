using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField]GameObject player;
    [SerializeField] GameObject flyer;
    [SerializeField] GameObject crawler;
    [SerializeField] GameObject boss;

    public override void InstallBindings()
    {
        Container.Bind<ILoader>().To<SaveLoadSystem>().AsSingle();
        Container.BindFactory<PlayerStateController, PlayerStateController.Factory>().FromComponentInNewPrefab(player);
        Container.BindFactory<FlyerStateController, FlyerStateController.Factory>().FromComponentInNewPrefab(flyer);
        Container.BindFactory<CrawlerStateController, CrawlerStateController.Factory>().FromComponentInNewPrefab(crawler);
        Container.BindFactory<BossStateController, BossStateController.Factory>().FromComponentInNewPrefab(boss);
        Container.BindInterfacesAndSelfTo<TargetsManager>().AsSingle();
    }
}

