using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackCrawlingFast")]
public class ZombieAttackCrawlingFast : Brainiac.Action
{
    protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        bool finished = agent.Blackboard.GetItem<bool>(ZombieStringReferences.Finished, false);

        if (finished)
        {
            return BehaviourNodeStatus.Failure;
        }

        if (agent.Zombie.CurrentHealth < agent.Zombie.Configuration.HealthIntervals[ZombieStringReferences.Finished])
        {
            agent.Blackboard.SetItem(ZombieStringReferences.Finished, true);
            agent.Zombie.SwitchToRagdoll();
            agent.Zombie.InvokeDeactivate();
            return BehaviourNodeStatus.Failure;
        }
        agent.transform.LookAt(new Vector3(agent.Zombie.PlayerReference.transform.position.x, agent.transform.position.y, agent.Zombie.PlayerReference.transform.position.z));
        return BehaviourNodeStatus.None;
    }
}