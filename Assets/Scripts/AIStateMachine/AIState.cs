using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State
{
    Idle,
    Order,
    Cooking,
    Delivery,
    Refueling,
    Sleep
}
public class AIState
{
    public enum Event
    {
        Enter,
        Update,
        Exit
    }

    public State name;
    protected Event stage;

    protected GameObject npc;
    protected Transform transformPosition;
    protected AIState nexState;
    protected NavMeshAgent agent;

    public AIState(GameObject _npc, NavMeshAgent _agent, Transform _transformPosition)
    {
        stage = Event.Enter;
        npc = _npc;
        agent = _agent;
        transformPosition = _transformPosition;
    }

    public virtual void Enter() { stage = Event.Update; }
    public virtual void Update() { stage = Event.Update; }
    public virtual void Exit() { stage = Event.Exit; }

    public AIState Process()
    {
        if (stage == Event.Enter) Enter();
        if (stage == Event.Update) Update();
        if (stage == Event.Exit)
        {
            Exit();
            return nexState;
        }

        return this;
    }
}
