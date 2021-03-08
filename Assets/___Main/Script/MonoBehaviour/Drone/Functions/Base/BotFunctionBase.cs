using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BotFunctionBase
{
    [SerializeField] protected List<ScoreCalculatorBase> _scoreCalculator;


    public abstract void Execute(DroneEnvironmentKnowledge knowledge);
}
