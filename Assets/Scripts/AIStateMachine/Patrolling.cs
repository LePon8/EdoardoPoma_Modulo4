using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : AIState
{
    int currentCheckpoint = -1;

    public Patrolling(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations)
        : base(_npc, _agent, _checkPoints, _timer, _destinations)
    {
        name = State.Patrolling;
        agent.speed = 4;
        agent.isStopped = false;
    }


    public override void Enter()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < checkPoints.Length; i++)
        {
            Transform tempCheckpoint = checkPoints[i];
            float distance = Vector3.Distance(npc.transform.position, tempCheckpoint.position);
            if (distance < lastDist)
            {
                currentCheckpoint = i - 1;
                lastDist = distance;
            }
        }

        base.Enter();
    }

    public override void Update()
    {
        if (agent.remainingDistance < 2)
        {
            if (currentCheckpoint >= checkPoints.Length - 1)
                currentCheckpoint = 0;
            else
                currentCheckpoint++;

            agent.SetDestination(checkPoints[currentCheckpoint].position);
        }

        if(timer >= 14)
        {
            nexState = new Sleep(npc, agent, checkPoints, timer, destinations);
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
