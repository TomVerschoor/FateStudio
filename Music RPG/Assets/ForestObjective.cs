using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestObjective : MonoBehaviour
{
    public bool Complete { private get; set; }
    GameObject[] enemies;
    private void Start()
    {
        Complete = true;
    }
    private void Update()
    {
        if (Complete){
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(enemies.Length);
            if (enemies.Length == 0)
            {
                SceneManager.LoadScene("CrystalCutscene", LoadSceneMode.Single);
            }
        }

        

    }

}
