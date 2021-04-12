using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackCrawlingSlow")]
public class ZombieAttackCrawlingSlow : Brainiac.Action
{
	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
	{
        bool finalAttack = agent.Blackboard.GetItem<bool>(ZombieStringReferences.FinalAttack, false);

        if (finalAttack)
        {
            return BehaviourNodeStatus.Failure;
        }

        if (agent.Zombie.CurrentHealth < agent.Zombie.Configuration.HealthIntervals[ZombieStringReferences.FinalAttack])
        {
            agent.Blackboard.SetItem(ZombieStringReferences.FinalAttack, true);
            agent.Zombie.Animator.SetTrigger(ZombieStringReferences.CrawlRunning);
            return BehaviourNodeStatus.Failure;
        }
        agent.transform.LookAt(new Vector3(agent.Zombie.PlayerReference.transform.position.x, agent.transform.position.y, agent.Zombie.PlayerReference.transform.position.z));
        return BehaviourNodeStatus.None;
    }
}