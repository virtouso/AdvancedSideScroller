using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackWalking")]
public class ZombieAttackWalking : Brainiac.Action
{
	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        bool alerted = agent.Blackboard.GetItem<bool>(ZombieStringReferences.Alerted,false);

        if (alerted)
        {
            return BehaviourNodeStatus.Failure;
        }

        if (agent.Zombie.CurrentHealth < agent.Zombie.Configuration.HealthIntervals[ZombieStringReferences.Alerted])
        {
            

            agent.Blackboard.SetItem(ZombieStringReferences.Alerted,true);
            agent.Zombie.Animator.SetTrigger(ZombieStringReferences.Run);


            return BehaviourNodeStatus.Failure;
        }
        agent.transform.LookAt(new Vector3(agent.Zombie.PlayerReference.transform.position.x, agent.transform.position.y, agent.Zombie.PlayerReference.transform.position.z));
        return BehaviourNodeStatus.None;


    }
}