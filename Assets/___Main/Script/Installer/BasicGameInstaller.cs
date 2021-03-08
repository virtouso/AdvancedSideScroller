using UnityEngine;
using Zenject;

public class BasicGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraSideFollow>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BaseLevelScenarioManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BasicGameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PoolManager>().FromComponentInHierarchy().AsSingle();
    }
}