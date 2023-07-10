using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    //[SerializeField] GameObject order;
    [SerializeField] Transform[] checkPoints;
    [SerializeField] Transform[] destinations;
    [SerializeField] GameObject foodPrefab;

    NavMeshAgent agent;
    AIState currentState;
    float timer;


    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(gameObject, agent, checkPoints, timer, destinations, foodPrefab);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState = currentState.Process();
    }

}
