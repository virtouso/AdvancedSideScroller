using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Move Left", menuName = "Moeen Assets/Drone Functions/ Move Left", order = int.MaxValue)]

public class MoveLeft : BotFunctionBase
{
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        knowledge.BotTransform.position += new Vector3(0,0,-knowledge.DroneConfiguration.HorizontalSpeed);
    }
}
