using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public static Stats Instance { get; private set; }

    public int MaxHealth { get; private set; }
    public double Health { get; private set; }
    public int MaxCombo { get; private set; }
    public int Combo { get; private set; }
    public string Scene { get; set; }

    public static int enemytype = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            MaxHealth = PlayerPrefs.GetInt("maxHealth", 10);
            Health = PlayerPrefs.GetInt("health", 10);
            MaxCombo = PlayerPrefs.GetInt("maxCombo", 5);
            Combo = PlayerPrefs.GetInt("combo", 0);
            Scene = PlayerPrefs.GetString("scene", "CutsceneApartment");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamange(double damage)
    {
        Health -= damage;
    }

    public void ResetCombo()
    {
        Combo = 0;
    }

    public void ResetStats()
    {
        Health = MaxHealth;
        Combo = 0;
    }

    public void ComboUp()
    {
        Combo++;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("maxHealth", MaxHealth);
        PlayerPrefs.SetInt("health", (int)Health);
        PlayerPrefs.SetInt("maxCombo", MaxCombo);
        PlayerPrefs.SetInt("combo", Combo);
        PlayerPrefs.SetString("scene", Scene);
    }

    private void Update()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}

