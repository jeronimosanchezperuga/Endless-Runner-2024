using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBotBehavior : MonoBehaviour
{
    public GameObject waypointGroup;
    public Transform[] waypoints;
    [SerializeField] SentryBotNavigation botNavigation;
    [SerializeField] SentryBotAnimationManager animationManager;
    public bool isPatrolling;
    public int currentWaypoint = 0;
    public float scanTime;
    // Start is called before the first frame update
    void Start()
    {
        UpdateWaypoints();
        botNavigation = GetComponent<SentryBotNavigation>();
        animationManager = GetComponentInChildren<SentryBotAnimationManager>();
    }

    private void UpdateWaypoints()
    {
        waypoints = waypointGroup.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrolling)
        {
            if (botNavigation.isArrived)
            {
                StartCoroutine(Scan(scanTime));
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
            botNavigation.SetDestination(waypoints[currentWaypoint]);
        }
    }

    IEnumerator Scan(float scanTime)
    {
        isPatrolling = false;
        animationManager.OpenDome(true);
        animationManager.CameraScan(true);
        yield return new WaitForSeconds(scanTime);
        animationManager.OpenDome(false);
        animationManager.CameraScan(true);
        isPatrolling=true;
    }
}
