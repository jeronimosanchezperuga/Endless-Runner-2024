using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SentryBotNavigation : MonoBehaviour
{
    public Transform targetTR;
    public NavMeshAgent agent;
    public float arrivalDistance;
    public bool isArrived;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTR)
        {
            agent.destination = targetTR.position;
        }

        isArrived = agent.remainingDistance < arrivalDistance;
        
    }

    public void SetDestination(Transform target)
    {
        targetTR = target;
    }
}
