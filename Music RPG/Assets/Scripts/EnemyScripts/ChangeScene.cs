using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class ChangeScene : MonoBehaviour
{
    public string newScene;
    public string objectName;
    public int enemyType;
    private GameObject[] enemies;

    public Animator transition;
    public float transitionTime = 1f;
    public ForestObjective objective;

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected");
        if (other.name == objectName)
        {
            other.gameObject.GetComponent<PlayerController>().SavePosition();
            SceneManager.LoadScene(newScene, LoadSceneMode.Single);
            Stats.enemytype = enemyType;
            this.transform.parent.GetComponent<EnemyOverworldSpawn>().spawn = false;
            
            
            try
            {
                objective = GameObject.Find("Objective").GetComponent<ForestObjective>();
                objective.Complete = false;
            }
            catch (NullReferenceException)
            {

            }
           


            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Enemy in enemies)
            {
                Destroy(Enemy);
            }

        }
    }
}