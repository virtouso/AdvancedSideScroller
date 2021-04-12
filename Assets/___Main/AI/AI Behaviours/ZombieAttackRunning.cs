using UnityEngine;
using System;
using System.Collections;
using Brainiac;

[AddNodeMenu("Action/ZombieAttackRunning")]
public class ZombieAttackRunning : Brainiac.Action
{

    protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        bool died = agent.Blackboard.GetItem<bool>(ZombieStringReferences.Died, false);

        if (died)
        {
            return BehaviourNodeStatus.Failure;
        }

        if (agent.Zombie.CurrentHealth < agent.Zombie.Configuration.HealthIntervals[ZombieStringReferences.Died])
        {
            agent.Blackboard.SetItem(ZombieStringReferences.Died, true);
            agent.Zombie.Animator.SetTrigger(ZombieStringReferences.Death);
            agent.Zombie.InvokeCrawling(agent.Zombie.Animator, agent.Zombie.Configuration);
            return BehaviourNodeStatus.Failure;
        }

        agent.transform.LookAt(new Vector3(agent.Zombie.PlayerReference.transform.position.x, agent.transform.position.y, agent.Zombie.PlayerReference.transform.position.z));

        return BehaviourNodeStatus.None;
    }



    private IEnumerator StartCrawling(Animator animator, ZombieConfiguration config)
    {
        yield return new WaitForSeconds(config.DeathTakeLong);
        animator.SetTrigger(ZombieStringReferences.Crawl);
    }
}