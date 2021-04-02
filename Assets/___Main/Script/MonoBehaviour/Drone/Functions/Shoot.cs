using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "Shoot", menuName = "Moeen Assets/Drone Functions/ Shoot", order = int.MaxValue)]
public class Shoot : BotFunctionBase
{
    [Inject] private PoolManager _poolManager;

    private float shootTimer;
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        Vector3 goalRotation = (knowledge.HuntingEnemy.Position - knowledge.BotTransform.position).normalized;
        knowledge.GunMuzzle.rotation = Quaternion.FromToRotation(knowledge.GunMuzzle.eulerAngles, goalRotation);
        shootTimer += Time.deltaTime;

        if (shootTimer < knowledge.DroneConfiguration.FireRate) return;
        shootTimer = 0;
        var bullet = _poolManager.ShootBullet(knowledge.GunMuzzle.position += knowledge.GunMuzzle.forward * 3, Quaternion.identity, knowledge.GunMuzzle.forward);
    }
}
