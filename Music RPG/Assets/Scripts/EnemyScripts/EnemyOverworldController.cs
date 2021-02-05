using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyOverworldController : MonoBehaviour
{
    static public bool firstInstance = true;
    static public GameObject currentEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        if (firstInstance)
        {
            DontDestroyOnLoad(gameObject);
            firstInstance = false;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "TrainEscape" || SceneManager.GetActiveScene().name == "ForestEnemyClear")
        {
            Destroy(gameObject);
            firstInstance = true;
        }
    }
}
