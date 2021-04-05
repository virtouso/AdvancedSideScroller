using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackCrawlingFast")]
public class ZombieAttackCrawlingFast : Brainiac.Action
{
	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        Debug.Log("zombie attack crawling fast");
        return BehaviourNodeStatus.None;
    }
}