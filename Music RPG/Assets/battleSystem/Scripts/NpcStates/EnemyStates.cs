using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyStates : MonoBehaviour
{
    public float lookRadius = 10f;

    private Transform target;
    private NavMeshAgent agent;
    private bool playerInRange;
    
    // Start is called before the first frame update
    private void Start()
    {   
        target = GameObject.Find("PlayerOverworld").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        playerInRange = (distance <= lookRadius);

        if (playerInRange)
        {
            Chase();
        }

        else
        {
            Idle();
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Idle()
    {

    }

    private void Chase()
    {
        agent.SetDestination(target.position);
    }
}
