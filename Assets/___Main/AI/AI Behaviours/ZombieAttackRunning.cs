using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackRunning")]
public class ZombieAttackRunning : Brainiac.Action
{


	


	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
	{
		Debug.Log("ZombieAttackRunning");
        return BehaviourNodeStatus.None;
    }
}