using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DistanceBetweenBotAndEnemyIsLessThanThreshold", menuName = "Moeen Assets/Drone Score Calculator/ DistanceBetweenBotAndEnemyIsLessThanThreshold", order = int.MaxValue)]

public class DistanceBetweenBotAndEnemyIsLessThanThreshold : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1 * _score;

        float sqrDistance = (knowledge.BotTransform.position - knowledge.HuntingEnemy.Position).sqrMagnitude;

        if (sqrDistance > knowledge.DroneConfiguration.AllowedDistanceToShoot) return 0;
        return _score;
    }
}
