using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieGoIdle")]
public class ZombieGoIdle : Brainiac.Action
{
	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
   
        UnityEngine.Debug.Log("Go Idle Is running");
        return BehaviourNodeStatus.Failure;
    }
}