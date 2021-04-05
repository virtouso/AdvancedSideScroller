using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackWalking")]
public class ZombieAttackWalking : Brainiac.Action
{
	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        Debug.Log("ZombieAttackWalking");
        return BehaviourNodeStatus.None;
	}
}