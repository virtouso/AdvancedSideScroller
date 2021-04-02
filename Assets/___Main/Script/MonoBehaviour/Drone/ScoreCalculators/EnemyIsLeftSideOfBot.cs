using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "EnemyIsLeftSideOfBot", menuName = "Moeen Assets/Drone Score Calculator/ EnemyIsLeftSideOfBot", order = int.MaxValue)]

public class EnemyIsLeftSideOfBot : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1 * _score;

        if (knowledge.BotTransform.position.x > knowledge.HuntingEnemy.Position.x) return 0;
        return _score;
    }
}
