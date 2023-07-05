using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    NavMeshAgent agent;
    AIState currentState;
    Transform transformPosition;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(gameObject, agent, transformPosition);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState = currentState.Process();
    }
}
