using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleep : AIState
{
    public Sleep(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations, GameObject _foodPrefab, GameObject _videoClip)
        : base(_npc, _agent, _checkPoints, _timer, _destinations, _foodPrefab, _videoClip)
    {
        name = State.Sleep;
        agent.speed = 4;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(destinations[0].position);

        if(agent.remainingDistance == 0)
        {
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, destinations[0].rotation, 5);
        }

        if(timer > 15)
        {
            nexState = new Eat(npc, agent, checkPoints, timer, destinations, foodPrefab, videoClip);
            stage = Event.Exit;
            return;
        }

        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

