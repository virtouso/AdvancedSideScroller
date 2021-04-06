using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Zombie : EnemyControllerBase
{
    public override Vector3 Position => transform.position;
    [SerializeField] public ZombieConfiguration Configuration;


  

    protected override void Awake()
    {
        base.Awake();
  
    }

    protected override void Update()
    {
        base.Update();
    }




}

[System.Serializable]
public class ZombieConfiguration
{
    public float DistanceToSeeHuman;
    public float DistanceToHearHuman;
}