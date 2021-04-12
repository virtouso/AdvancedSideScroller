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
        UnityEngine.Debug.Log("number of detected enemies:::" + enemyColliders.Length);


        // if (knowledge.EnemiesInRange.Count > 0) return -1 * _score;

        if (enemyColliders.Length > 0)
        {

            List<EnemyControllerBase> enemies = new List<EnemyControllerBase>();

            foreach (var enemyCollider in enemyColliders)
            {
                var enemy = enemyCollider.transform.root.GetComponent<EnemyControllerBase>();
                if (enemies.Contains(enemy))
                    continue;
                enemies.Add(enemy);
                knowledge.EnemiesInRange = enemies;
                Debug.Log("enemies number::::" + enemies.Count);
            }

            return -1 * _score;
        }




        return _score;
    }
}
