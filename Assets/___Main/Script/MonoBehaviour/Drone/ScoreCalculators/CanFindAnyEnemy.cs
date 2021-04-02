using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Can Find Any Enemy", menuName = "Moeen Assets/Drone Score Calculator/ Can Find Any Enemy", order = int.MaxValue)]
public class CanFindAnyEnemy : ScoreCalculatorBase
{
    [SerializeField] private LayerMask _detectionLayer;
    [SerializeField] private float _range;
    public override int Execute(DroneEnvironmentKnowledge knowledge)
    {

        var enemyColliders = Physics.OverlapSphere(knowledge.BotTransform.position, _range, _detectionLayer);

        if (enemyColliders.Length <= 0)
        {
            return -1 * _score;
        }


        List<EnemyControllerBase> enemies = new List<EnemyControllerBase>();

        foreach (var enemyCollider in enemyColliders)
        {
            enemies.Add(enemyCollider.GetComponent<EnemyControllerBase>());
        }

        return _score;
    }
}
