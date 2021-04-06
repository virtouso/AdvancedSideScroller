using UnityEngine;
using System;
using Brainiac;

[AddNodeMenu("Action/ZombieGoIdle")]
public class ZombieGoIdle : Brainiac.Action
{



	protected override BehaviourNodeStatus OnExecute(AIAgent agent)
    {
        //todo check hear sound
        float distanceToHuman = agent.Zombie.Configuration.DistanceToHearHuman *
                                agent.Zombie.Configuration.DistanceToHearHuman;

        bool playerSeen= agent.Blackboard.GetItem<bool>("player_seen",false);
        bool playerHeard = agent.Blackboard.GetItem<bool>("player_heard", false);

        if (playerSeen|| playerHeard)
        {
            return BehaviourNodeStatus.Failure;
        }


        if ((agent.transform.position - agent.Zombie.Position).sqrMagnitude < distanceToHuman)
        {

        }


        //todo check seeing player

        UnityEngine.Debug.Log("Go Idle Is running");
    }
}