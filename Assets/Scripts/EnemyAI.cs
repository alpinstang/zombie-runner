using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] public float chaseRange = 5f;
    bool isProvoked = false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(isProvoked)
        {
            EngageTarget();
        } else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget <= chaseRange)
        {
            ChaseTarget();
        }

        if()
        print("enemy attacking player!");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
