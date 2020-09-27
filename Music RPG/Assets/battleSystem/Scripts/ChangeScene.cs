using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string newScene;
    public string objectName;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.name == objectName)
        {
            SceneManager.LoadScene(newScene, LoadSceneMode.Single);
        }
    }
}
