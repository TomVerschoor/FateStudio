using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetposition : MonoBehaviour
{
    private string objectName = "Player";
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.name == objectName)
        {
            PlayerPrefs.DeleteKey("PlayerX");
            PlayerPrefs.DeleteKey("PlayerY");
            PlayerPrefs.DeleteKey("PlayerZ");
        }
    }
}
