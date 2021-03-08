using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScoreCalculatorBase
{
    public abstract int Execute(DroneEnvironmentKnowledge knowledge);
}
