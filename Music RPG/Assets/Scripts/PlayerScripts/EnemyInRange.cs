using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRange : MonoBehaviour
{
    // Checks if the enemy is in range to play the chase music
    private float lookRadius = 15f;

    // Plays the actual chase music
    public FMODMusicManager chaseMusic;

    // Array of enemies
    GameObject[] enemies;

    //private Transform target;
    private bool enemyInRange;


    // Update is called once per frame
    void Update()
    {
        // refreshes the enemies in the scene and doesn't give errors that it got destroyed after changing scenes
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyInRangeChecker();
    }

    // Checks to see which enemy is close and if they are in range to play the chase music
    private void EnemyInRangeChecker()
    {
        if (enemies.Length == 0)
        {
            Debug.Log("No Enemies were found in this scene.");
            return;
        }
        else
        {
            GameObject closest = null;
            Vector3 Playerposition = transform.position;
            float distance = Mathf.Infinity;

            foreach (var enemy in enemies)
            {
                Vector3 diff = enemy.transform.position - Playerposition;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    closest = enemy;
                    distance = curDistance;

                    float distanceFromEnemy = Vector3.Distance(closest.transform.position, transform.position);
                    enemyInRange = (distanceFromEnemy <= lookRadius);
                    Debug.Log("distance: " + distanceFromEnemy);

                    if (!enemyInRange)
                    {
                        chaseMusic.IsChasing(0f);
                    }
                    else if (enemyInRange)
                    {
                        chaseMusic.IsChasing(1f);
                    }
                }
            }
        }
    }
}
