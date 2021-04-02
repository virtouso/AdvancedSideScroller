using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "Find Enemies", menuName = "Moeen Assets/Drone Functions/ Find Enemies", order = int.MaxValue)]
public class FindEnemies : BotFunctionBase
{
    [Inject] private PoolManager _poolManager;

    private float shootTimer;
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        // todo probably nothing
    }
}
