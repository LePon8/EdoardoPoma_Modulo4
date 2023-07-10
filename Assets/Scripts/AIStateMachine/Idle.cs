using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations, GameObject _foodPrefab)
        : base(_npc, _agent, _checkPoints, _timer, _destinations, _foodPrefab)
    {
        name = State.Idle;
    }

    public override void Enter()
    {
        
        base.Enter();
    }

    public override void Update()
    {
        if(timer >= 1)
        {
            nexState = new Patrolling(npc, agent, checkPoints, timer, destinations, foodPrefab);
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
