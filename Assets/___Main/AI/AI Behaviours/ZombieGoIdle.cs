using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieGoIdle")]
public class ZombieGoIdle : Brainiac.Action
{



    protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        //todo check hear sound


        bool playerSeen = agent.Blackboard.GetItem<bool>(ZombieStringReferences.PlayerSeen, false);
        bool playerHeard = agent.Blackboard.GetItem<bool>(ZombieStringReferences.PlayerHeard, false);

        if (playerSeen || playerHeard)
        {
            return BehaviourNodeStatus.Failure;
        }

        float distanceToHuman = agent.Zombie.Configuration.DistanceToHearHuman *
                                agent.Zombie.Configuration.DistanceToHearHuman;
        if ((agent.Zombie.PlayerReference.transform.position - agent.Zombie.Position).sqrMagnitude < distanceToHuman)
        {
            agent.Blackboard.SetItem(ZombieStringReferences.PlayerHeard, true);
            UpdateTransform(agent);
            return BehaviourNodeStatus.Failure;
        }

        RaycastHit hit;
        bool checkPlayer = Physics.Raycast(agent.transform.position, agent.transform.forward, out hit, agent.Zombie.Configuration.DistanceToSeeHuman, agent.Zombie.DetectionMask);
        if (checkPlayer)
        {
            if (hit.transform.name == ZombieStringReferences.HuntingGoal)
            {
                agent.Blackboard.SetItem(ZombieStringReferences.PlayerSeen, true);
                UpdateTransform(agent);
                return BehaviourNodeStatus.Failure;
            }

        }

        return BehaviourNodeStatus.None;

    }



    private void UpdateTransform(AIAgent agent)
    {
      
        agent.transform.LookAt(new Vector3(agent.Zombie.PlayerReference.transform.position.x, agent.transform.position.y, agent.Zombie.PlayerReference.transform.position.z));
        agent.Zombie.Animator.SetTrigger(ZombieStringReferences.Walk);
    }




}