using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SentryBotNavigation : MonoBehaviour
{
    public Transform targetTR;
    public Animator anim;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        anim = transform.GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targetTR.position;
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void SetDestination(Transform target)
    {
        targetTR = target;
    }
}
