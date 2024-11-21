using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SentryBotBehavior : MonoBehaviour
{
    public GameObject waypointGroup;
    public Transform[] waypoints;
    [SerializeField] SentryBotAnimationManager animationManager;
    public bool isPatrolling;
    public int currentWaypoint = 0;
    public float scanTime;
    public Transform targetTR;
    public NavMeshAgent agent;
    public bool isArrived;
    // Start is called before the first frame update
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        UpdateWaypoints();
        animationManager = GetComponentInChildren<SentryBotAnimationManager>();
    }

    private void UpdateWaypoints()
    {
        waypoints = waypointGroup.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTR)
        {
            agent.destination = targetTR.position;
        }

        isArrived = agent.remainingDistance < agent.stoppingDistance;

        if (isPatrolling)
        {
            if (isArrived)
            {                
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }
                Debug.Log("Scan");
                StartCoroutine(Scan(scanTime));
            }
            agent.destination = waypoints[currentWaypoint].position;
        }
    }

    IEnumerator Scan(float scanTime)
    {
        isPatrolling = false;
        animationManager.OpenDome(true);
        animationManager.CameraScan(true);
        Debug.Log("Dome open: true");
        yield return new WaitForSeconds(scanTime);
        Debug.Log("Dome open: false");
        animationManager.OpenDome(false);
        animationManager.CameraScan(false);
        isPatrolling = true;
    }
}
