using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaController : MonoBehaviour
{
    static public int lives;
    static public int enemyLives;
    public string returnScene;
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives", 5);
        enemyLives = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            enemyLives += 1;
        }
        if (Input.GetKeyDown("j"))
        {
            enemyLives -= 1;
        }
        if (Input.GetKeyDown("m"))
        {
            lives += 1;
        }
        if (Input.GetKeyDown("n"))
        {
            lives -= 1;
        }
        if (enemyLives == 0 | lives == 0)
        {
            SceneManager.LoadScene(returnScene, LoadSceneMode.Single);
        }
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("lives", lives);
    }
}
