using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Bot Configuration", menuName = "Moeen Assets/Drone Configuration", order = int.MaxValue)]
public class DroneConfiguration : ScriptableObject
{

    [SerializeField] public float AllowedDistanceToShoot;
    [SerializeField] public float AllowedDistanceToMoveHorizontally;
    [SerializeField] public float AllowedDistanceToMoveVertically;
    [SerializeField] public float ThresholdOverEnemy;
    [SerializeField] public float ThresholdUnderEnemy;
    [SerializeField] public float ThresholdToDetectEnemy;
    [SerializeField] public float FireRate;
    [SerializeField] public float AscendSpeed;
    [SerializeField] public float DescendSpeed;
    [SerializeField] public float HorizontalSpeed;
}
