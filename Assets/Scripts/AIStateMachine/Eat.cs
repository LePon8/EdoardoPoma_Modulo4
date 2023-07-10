using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eat : AIState
{
    public Eat(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations, GameObject _foodPrefab)
        : base(_npc, _agent, _checkPoints, _timer, _destinations, _foodPrefab)
    {
        name = State.Eat;
        agent.speed = 4;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(destinations[1].position);

        if(timer >= 40)
        {
            agent.SetDestination(destinations[2].position);
            foodPrefab.SetActive(true);

            if (agent.remainingDistance == 0)
            {
                npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, destinations[2].rotation, 5);
            }

            if(timer >= 50)
            {
                foodPrefab.SetActive(false);
                timer = 0;

                nexState = new Idle(npc, agent, checkPoints, timer, destinations, foodPrefab);
                stage = Event.Exit;
                return;
            }
        }

        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
