using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{

    public string newScene;
    private string objectName = "Player";

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.name == objectName)
        {
            SceneManager.LoadScene(newScene, LoadSceneMode.Single);
            PlayerPrefs.DeleteKey("playerX");
            PlayerPrefs.DeleteKey("playerY");
            PlayerPrefs.DeleteKey("playerZ");
        }

    }
}
