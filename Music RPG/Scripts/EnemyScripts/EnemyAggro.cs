using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAggro : MonoBehaviour
{
   private float lookRadius = 15f;

    Animator animator;
    private int playerInRangeHash = Animator.StringToHash("playerInRange");

    private Transform target;
    private Vector3 originalPosition;
    private NavMeshAgent agent;
    private bool playerInRange;

    private Vector3 randomPosition;
    private float waitTime = 3f;
    private float currentWaitTime;

    public float minX = -5, minZ = -5, maxX = 5, maxZ = 5;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentWaitTime = waitTime;
        originalPosition = gameObject.transform.position;
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null) return;
        
        float distance = Vector3.Distance(target.position, transform.position);
        playerInRange = (distance <= lookRadius);

        if (playerInRange)
        {
            FacePlayer();
            Chase();
        }
        else
        {
            Patrolling();

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Chase()
    {
        animator.SetBool(playerInRangeHash, true);
        agent.SetDestination(target.position);
        currentWaitTime = waitTime;
    }

    private void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void generateRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        randomPosition = new Vector3(originalPosition.x + x, 0, originalPosition.z + z);;
    }

    private void moveToDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    private void Patrolling()
    {
        if (agent.remainingDistance < 0.4f)
        {
            if (currentWaitTime <= 0)
            {
                generateRandomPosition();
                moveToDestination(randomPosition);
                currentWaitTime = waitTime;
                animator.SetBool(playerInRangeHash, true);
            }
            else
            {
                animator.SetBool(playerInRangeHash, false);
                currentWaitTime -= Time.deltaTime;
            }
        }
    }
}