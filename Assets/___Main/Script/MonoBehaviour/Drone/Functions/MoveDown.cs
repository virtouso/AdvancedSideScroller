using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Move Down", menuName = "Moeen Assets/Drone Functions/Move Down", order = int.MaxValue)]

public class MoveDown : BotFunctionBase
{
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        knowledge.BotTransform.position += new Vector3(0, knowledge.DroneConfiguration.DescendSpeed, 0);
    }
}
