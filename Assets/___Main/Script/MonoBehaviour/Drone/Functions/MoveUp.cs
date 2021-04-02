using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Move Up", menuName = "Moeen Assets/Drone Functions/ Move Up", order = int.MaxValue)]

public class MoveUp : BotFunctionBase
{
    public override void Execute(DroneEnvironmentKnowledge knowledge)
    {
        knowledge.BotTransform.position += new Vector3(0, knowledge.DroneConfiguration.AscendSpeed, 0);

    }
}
