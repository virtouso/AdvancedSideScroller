using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Move Right", menuName = "Moeen Assets/Drone Functions/ Move Right", order = int.MaxValue)]

public class MoveRight : BotFunctionBase
{
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        knowledge.BotTransform.position += new Vector3(0, 0, knowledge.DroneConfiguration.HorizontalSpeed);

    }
}
