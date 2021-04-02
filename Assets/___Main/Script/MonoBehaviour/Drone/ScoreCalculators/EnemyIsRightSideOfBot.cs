using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIsRightSideOfBot", menuName = "Moeen Assets/Drone Score Calculator/ EnemyIsRightSideOfBot", order = int.MaxValue)]

public class EnemyIsRightSideOfBot : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1 * _score;

        if (knowledge.BotTransform.position.x < knowledge.HuntingEnemy.Position.x) return 0;
        return _score;
    }
}
