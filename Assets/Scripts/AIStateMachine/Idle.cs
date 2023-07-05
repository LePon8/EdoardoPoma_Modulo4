using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform _tranformPositon)
        : base(_npc, _agent, _tranformPositon)
    {
        name = State.Idle;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Suca");
        }
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
