using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyIsUpperThanBotWithThreshold", menuName = "Moeen Assets/Drone Score Calculator/ EnemyIsUpperThanBotWithThreshold", order = int.MaxValue)]

public class EnemyIsUpperThanBotWithThreshold : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1*_score;
        if (knowledge.BotTransform.position.y < knowledge.HuntingEnemy.Position.y + knowledge.DroneConfiguration.ThresholdOverEnemy) return 0;
        return _score;
    }
}
