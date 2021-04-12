using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "Shoot", menuName = "Moeen Assets/Drone Functions/ Shoot", order = int.MaxValue)]
public class Shoot : BotFunctionBase
{


    private float shootTimer;
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return;
        shootTimer += Time.deltaTime;
        Vector3 goalRotation = (knowledge.HuntingEnemy.Position - knowledge.BotTransform.position).normalized;


        if (shootTimer < knowledge.DroneConfiguration.FireRate) return;
        shootTimer = 0;
        Vector3 goalDirection = (knowledge.HuntingEnemy.Position - knowledge.BotTransform.position).normalized;
        var bullet = knowledge.BotTransform.GetComponent<DroneController>().PoolManager.ShootBullet(knowledge.BotTransform.position, Quaternion.identity, goalDirection);
    }
}
