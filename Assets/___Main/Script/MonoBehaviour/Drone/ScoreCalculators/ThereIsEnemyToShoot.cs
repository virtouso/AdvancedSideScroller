using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ThereIsEnemyTo Shoot", menuName = "Moeen Assets/Drone Score Calculator/ ThereIsEnemyToShoot", order = int.MaxValue)]

public class ThereIsEnemyToShoot: ScoreCalculatorBase
{
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {


        if (knowledge.HuntingEnemy != null )
        {

            return _score;
        };


        return -1 * _score;
    }
}