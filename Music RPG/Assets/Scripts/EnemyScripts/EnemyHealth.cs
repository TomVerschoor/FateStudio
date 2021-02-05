using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int enemyLives = 10;
    private ParticleSystem particleSystem;
    public string ReturnScene { get; set; }

    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    
    public void EnemyDies()
    {
        if (enemyLives <= 0)
        {
            SceneManager.LoadScene(ReturnScene, LoadSceneMode.Single);
        }
    }

    public void TakeDamage(int damage)
    {
        particleSystem.Play();
        enemyLives -= damage;
    }

    public int GetEnemyLives()
    {
        return enemyLives;
    }

    public void SetEnemyLives(int enemyLives)
    {
        this.enemyLives = enemyLives;
    }
}
