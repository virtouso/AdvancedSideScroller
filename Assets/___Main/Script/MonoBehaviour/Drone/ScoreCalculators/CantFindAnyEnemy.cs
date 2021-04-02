using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Cant Find Any Enemy", menuName = "Moeen Assets/Drone Score Calculator/ Cant Find Any Enemy", order = int.MaxValue)]
public class CantFindAnyEnemy : ScoreCalculatorBase
{
    [SerializeField] private LayerMask _detectionLayer;
    [SerializeField] private float _range;
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {

        var enemyColliders = Physics.OverlapSphere(knowledge.BotTransform.position, _range, _detectionLayer);

        if (enemyColliders.Length <= 0)
        {
            return _score;
        }

        return -1 * _score;
    }
}