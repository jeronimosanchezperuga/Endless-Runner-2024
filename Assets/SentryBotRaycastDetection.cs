using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBotRaycastDetection : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLenght;
    public LayerMask layerMask;
    public SentryBotBehavior behavior;

    // Start is called before the first frame update
    void Awake()
    {
        behavior = GetComponent<SentryBotBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLenght, layerMask))
        {
            if (behavior.isPatrolling)
            {
                behavior.isPatrolling = false;
                behavior.targetTR = hit.collider.GetComponent<Transform>();
                Debug.Log("Player detected!");
                
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * rayLenght);
    }
}
