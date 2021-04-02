using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "ThereIsNothingBetweenBotAndEnemy", menuName = "Moeen Assets/Drone Score Calculator/ ThereIsNothingBetweenBotAndEnemy", order = int.MaxValue)]

public class ThereIsNothingBetweenBotAndEnemy : ScoreCalculatorBase
{
    [SerializeField] private LayerMask _obstacleLayer;

    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {
        if (knowledge.HuntingEnemy == null) return -1 * _score;


        Vector3 direction = (knowledge.HuntingEnemy.Position - knowledge.BotTransform.position).normalized;
        bool goalObscured = Physics.Raycast(knowledge.BotTransform.position,direction,knowledge.DroneConfiguration.ThresholdToDetectEnemy,_obstacleLayer);

        if (goalObscured) return 0;

        return _score;

    }
}
