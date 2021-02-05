using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Arena enemy
    ArenaEnemy arenaEnemy;

    //public int enemyType = 10;
    public GameObject spawnPoint;
    public GameObject projectile;
    public int rangeBeatStep = 0;
    public double rangeDam = 1;
    public GameObject shockwave;
    public int shockwaveBeatStep = 0;
    public double shockDam = 1;
    public GameObject danger;
    public int spreadBeatStep = 0;
    public GameObject shield;

    //Enemy AI
    EnemyAI enemyAI;

    private NavMeshAgent agent;
    private Animator animator;

    //Enemy health
    public int enemyHealthPoints;
    EnemyHealth enemyHealth;
    
    public string returnScene;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.ReturnScene = returnScene;
        if (enemyHealthPoints != 0)
        {
            enemyHealth.SetEnemyLives(enemyHealthPoints);
        }

        animator = GetComponentInChildren<Animator>();

        //enemyTypeSwitcher();
        arenaEnemy = new ArenaEnemy(transform, animator, spawnPoint, projectile, rangeBeatStep, rangeDam, shockwave, shockwaveBeatStep, shockDam, danger, spreadBeatStep, shield);
        
        agent = GetComponent<NavMeshAgent>();
        enemyAI = new EnemyAI(transform, agent, animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.gameIsPaused && !TutorialController.OverlayOn)
        {
            arenaEnemy.EnemyBehaviour();
            arenaEnemy.playerPos = enemyAI.target;
            arenaEnemy.enemyPos = enemyAI.enemyPos;
            if (arenaEnemy.dangerZoneOnBeat)
            {
                //arenaEnemy.stand = true;
                enemyAI.stand = true;
            }
            if (arenaEnemy.spreadOnBeat)
            {
                //arenaEnemy.stand = false;
                enemyAI.stand = false;
            }
            enemyAI.EnemyInteligience();
            enemyHealth.EnemyDies();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAI == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyAI.SightRadius);
        Gizmos.DrawWireSphere(transform.position, enemyAI.TetherRadius);
    }

    //private void enemyTypeSwitcher()
    //{
    //    Debug.Log("Enemytype: " + enemyType);
    //    //enemyType = Stats.enemytype++;
    //    switch (enemyType)
    //    {
    //        case 0:
    //            this.rangeBeatStep = 8;
    //            break;
    //        case 1:
    //            this.rangeBeatStep = 8;
    //            break;
    //        case 2:
    //            this.rangeBeatStep = 4;
    //            break;
    //        case 3:
    //            this.rangeBeatStep = 4;
    //            break;
    //        case 4:
    //            this.rangeBeatStep = 4;
    //            break;
    //        case 5:
    //            this.rangeBeatStep = 4;
    //            this.shockwaveBeatStep = 8;
    //            break;
    //        default:
    //            break;
    //    }

    //}
}
