using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies; 
    
    void Start()
    {
        if (Stats.enemytype > enemies.Length)
            Stats.enemytype = enemies.Length;
        
        Instantiate(enemies[Stats.enemytype], transform.position, Quaternion.identity);
    }
}
