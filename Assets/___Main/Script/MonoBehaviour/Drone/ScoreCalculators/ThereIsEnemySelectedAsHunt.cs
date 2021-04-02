﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ThereIsEnemySelectedAsHunt", menuName = "Moeen Assets/Drone Score Calculator/ ThereIsEnemySelectedAsHunt", order = int.MaxValue)]

public class ThereIsEnemySelectedAsHunt : ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy != null) return -1 *_score;
        return _score;
    }
}
