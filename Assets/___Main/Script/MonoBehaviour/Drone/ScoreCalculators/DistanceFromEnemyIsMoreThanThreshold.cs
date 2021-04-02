using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DistanceFromEnemyIsMoreThanThreshold", menuName = "Moeen Assets/Drone Score Calculator/ DistanceFromEnemyIsMoreThanThreshold", order = int.MaxValue)]

public class DistanceFromEnemyIsMoreThanThreshold : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1 * _score;

        float sqrDist = (knowledge.BotTransform.position - knowledge.HuntingEnemy.Position).sqrMagnitude;

        if (sqrDist < knowledge.DroneConfiguration.AllowedDistanceToMoveHorizontally) return 0;
        return _score;
    }
}
