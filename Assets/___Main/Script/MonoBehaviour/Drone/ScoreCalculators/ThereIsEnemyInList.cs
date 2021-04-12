using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ThereIsEnemyInList", menuName = "Moeen Assets/Drone Score Calculator/ ThereIsEnemyInList", order = int.MaxValue)]

public class ThereIsEnemyInList : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.EnemiesInRange.Count <= 0) return -1*_score;
        return _score;
    }
}
