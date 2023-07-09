using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State
{
    Idle,
    Patrolling,
    Eat,
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
    protected Transform[] checkPoints;
    protected Transform[] destinations;
    protected AIState nexState;
    protected NavMeshAgent agent;
    protected float timer;

    public AIState(GameObject _npc, NavMeshAgent _agent, Transform[] _checkPoints, float _timer, Transform[] _destinations)
    {
        stage = Event.Enter;
        npc = _npc;
        agent = _agent;
        checkPoints = _checkPoints;
        timer = _timer;
        destinations = _destinations;
    }

    public virtual void Enter() { stage = Event.Update; }
    public virtual void Update() { stage = Event.Update; timer += Time.deltaTime; }
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
