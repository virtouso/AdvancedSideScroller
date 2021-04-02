using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Select New Hunt", menuName = "Moeen Assets/Drone Functions/ Select New Hunt", order = int.MaxValue)]

public class SelectNewHunt : BotFunctionBase
{
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        // todo for now its just rudimentary
        knowledge.HuntingEnemy = FindNearestEnemy(knowledge);
    }



    EnemyControllerBase FindNearestEnemy(DroneEnvironmentKnowledge knowledge)
    {
        float nearestDistance = float.MaxValue;
        EnemyControllerBase nearestEnemy = null;

        for (int i = 0; i < knowledge.EnemiesInRange.Count; i++)
        {
            float distance = (knowledge.EnemiesInRange[i].Position - knowledge.BotTransform.position).sqrMagnitude;
        }

        return nearestEnemy;
    }



}
