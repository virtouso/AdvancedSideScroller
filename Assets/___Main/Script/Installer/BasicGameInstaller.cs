using UnityEngine;
using Zenject;

public class BasicGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraSideFollow>().FromComponentInHierarchy().AsSingle();
    }
}