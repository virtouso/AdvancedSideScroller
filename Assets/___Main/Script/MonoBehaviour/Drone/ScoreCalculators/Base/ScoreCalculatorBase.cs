using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ScoreCalculatorBase : ScriptableObject
{
    [SerializeField] protected int _score;  
    public abstract int Execute(DroneEnvironmentKnowledge knowledge);
}
