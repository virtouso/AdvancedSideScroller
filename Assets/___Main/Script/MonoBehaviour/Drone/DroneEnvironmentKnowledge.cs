using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEnvironmentKnowledge
{
    public Transform BotTransform;

    public List<EnemyControllerBase> EnemiesInRange;
    public EnemyControllerBase HuntingEnemy;
    public DroneConfiguration DroneConfiguration;

    public DroneEnvironmentKnowledge(Transform botTransform, List<EnemyControllerBase> enemiesInRange, EnemyControllerBase huntingEnemy, DroneConfiguration droneConfiguration)
    {
        BotTransform = botTransform;
    
        EnemiesInRange = enemiesInRange;
        HuntingEnemy = huntingEnemy;
        DroneConfiguration = droneConfiguration;
    }

}
