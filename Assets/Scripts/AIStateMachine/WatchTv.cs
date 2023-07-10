using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WatchTv : AIState
{
    public WatchTv(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations, GameObject _foodPrefab, GameObject _videoClip)
        : base(_npc, _agent, _checkPoints, _timer, _destinations, _foodPrefab, _videoClip)
    {
        name = State.WatchTv;
        agent.speed = 4;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(destinations[3].position);

        if (agent.remainingDistance == 0)
        {
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, destinations[3].rotation, 5);
            videoClip.SetActive(true);
        }

        if (timer > 68)
        {
            videoClip.SetActive(false);
            timer = 0;

            nexState = new Idle(npc, agent, checkPoints, timer, destinations, foodPrefab, videoClip);
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
