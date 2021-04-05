using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : EnemyControllerBase
{
    public override Vector3 Position => transform.position;

    [SerializeField] public Animator Animator;



}
