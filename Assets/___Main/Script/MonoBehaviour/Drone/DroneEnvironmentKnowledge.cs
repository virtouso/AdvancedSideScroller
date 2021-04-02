using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEnvironmentKnowledge
{
    public Transform BotTransform;
    public Transform GunMuzzle;
    public List<EnemyControllerBase> EnemiesInRange;
    public EnemyControllerBase HuntingEnemy;
    public DroneConfiguration DroneConfiguration;

    public DroneEnvironmentKnowledge(Transform botTransform, Transform gunMuzzle, List<EnemyControllerBase> enemiesInRange, EnemyControllerBase huntingEnemy, DroneConfiguration droneConfiguration)
    {
        BotTransform = botTransform;
        GunMuzzle = gunMuzzle;
        EnemiesInRange = enemiesInRange;
        HuntingEnemy = huntingEnemy;
        DroneConfiguration = droneConfiguration;
    }

}
