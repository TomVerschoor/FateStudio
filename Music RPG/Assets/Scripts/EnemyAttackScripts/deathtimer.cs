using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathtimer : MonoBehaviour
{

    public float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
