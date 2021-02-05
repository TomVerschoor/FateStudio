using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZone : MonoBehaviour
{
    private void OnDestroy()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        }
    }
}
