using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyroomEvent : MonoBehaviour
{
    public GameObject SceneTrigger;
    // Start is called before the first frame update
    void Start()
    {
        SceneTrigger.GetComponent<ExitTrigger>().newScene = "TutorialRoom";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player collided with event");
            Instantiate(SceneTrigger, new Vector3(-18, 1, 5), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
