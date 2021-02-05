using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectiveTracker : MonoBehaviour
{
    GameObject[] Objective;


    private void OnDestroy()
    {
        Objective = GameObject.FindGameObjectsWithTag("Objective");
        foreach (GameObject ObjectiveObject in Objective)
        {
            Destroy(ObjectiveObject);
        }

    }
}
