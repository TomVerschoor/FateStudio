using UnityEngine;
using UnityEngine.AI;

class EnemyAI : MonoBehaviour
{
    public float SightRadius { get; set; }
    public float TetherRadius { get; set; }

    public Transform enemyPos;
    public Transform target;
    private NavMeshAgent agent;

    public bool stand = false;
    private bool playerInSightRange;
    private bool playerInTetherRange;

    private Animator animator;
    private int playerInRangeHash = Animator.StringToHash("playerInRange");

    // Start is called before the first frame update
    public EnemyAI(Transform transform, NavMeshAgent agent, Animator animator)
    {
        this.enemyPos = transform;
        this.agent = agent;
        this.animator = animator;
        target = GameObject.Find("Player").transform;

        SightRadius = 50.0f;
        TetherRadius = 10.0f;
    }

    // Update is called once per frame
    public void EnemyInteligience()
    {
        float distanceForSight = Vector3.Distance(target.position, enemyPos.position);
        float distanceForTether = Vector3.Distance(target.position, enemyPos.position);

        playerInSightRange = (distanceForSight <= SightRadius);
        playerInTetherRange = (distanceForTether <= TetherRadius);

        if (stand)
        {
            agent.SetDestination(enemyPos.position);
            animator.SetBool(playerInRangeHash, false);

        }
        if (!stand)
        {
            if (playerInSightRange && !playerInTetherRange)
            {
                animator.SetBool(playerInRangeHash, true);
                Chase();
            }
            if (playerInTetherRange && playerInSightRange)
            {
                animator.SetBool(playerInRangeHash, false);
                Tether();
            }
        }
    }

    private void Chase()
    {
        agent.SetDestination(target.position);
    }

    private void Tether()
    {
        agent.SetDestination(enemyPos.position);

        Vector3 targetPostition = new Vector3(target.position.x, enemyPos.position.y, target.position.z);
        enemyPos.LookAt(targetPostition);

        //transform.LookAt(target);
    }
}
