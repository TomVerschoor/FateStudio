using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldController : MonoBehaviour
{
    static public int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("lives", lives);
    }
}
