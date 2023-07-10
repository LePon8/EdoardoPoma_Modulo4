using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations, GameObject _foodPrefab, GameObject _videoClip)
        : base(_npc, _agent, _checkPoints, _timer, _destinations, _foodPrefab, _videoClip)
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
            nexState = new Sleep(npc, agent, checkPoints, timer, destinations, foodPrefab, videoClip);
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
