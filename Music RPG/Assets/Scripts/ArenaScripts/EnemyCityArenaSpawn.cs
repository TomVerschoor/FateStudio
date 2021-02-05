using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCityArenaSpawn : MonoBehaviour
{
    public GameObject EnemyObject;
    public bool spawn = true;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnLevelWasLoaded()
    {
        //Debug.Log("Awake. Spawn= " + spawn);
        if (spawn)
        {
            currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "CityArena")
            {
                Instantiate(EnemyObject, gameObject.transform);
                //Debug.Log("Spawned Object Enemy" + gameObject.transform.position);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

