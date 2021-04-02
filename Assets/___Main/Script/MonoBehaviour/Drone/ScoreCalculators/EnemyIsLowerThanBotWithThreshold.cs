using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyIsLowerThanBotWithThreshold", menuName = "Moeen Assets/Drone Score Calculator/ EnemyIsLowerThanBotWithThreshold", order = int.MaxValue)]

public class EnemyIsLowerThanBotWithThreshold : ScoreCalculatorBase
{

    

    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1 * _score;
        if (knowledge.BotTransform.position.y < knowledge.HuntingEnemy.Position.y+ knowledge.DroneConfiguration.ThresholdUnderEnemy) return 0;
        return _score;
    }
}
