using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations)
        : base(_npc, _agent, _checkPoints, _timer, _destinations)
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
            nexState = new Patrolling(npc, agent, checkPoints, timer, destinations);
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
