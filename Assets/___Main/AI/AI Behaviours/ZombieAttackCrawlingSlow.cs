using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackCrawlingSlow")]
public class ZombieAttackCrawlingSlow : Brainiac.Action
{
	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
	{
		Debug.Log("ZombieAttackCrawlingSlow");
        return BehaviourNodeStatus.None;
    }
}