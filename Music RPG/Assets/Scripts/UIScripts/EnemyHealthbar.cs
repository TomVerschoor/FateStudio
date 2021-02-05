using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Gradient healthGradient;
    public Image fill;

    private Slider slider;
    private EnemyHealth enemyHealth;

    void Start()
    {
        slider = GetComponent<Slider>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        slider.maxValue = enemyHealth.GetEnemyLives();
    }

    void Update()
    {
        //Debug.Log("enemy lives: " + enemyHealth.GetEnemyLives());
        slider.value = enemyHealth.GetEnemyLives();

        fill.color = healthGradient.Evaluate(slider.normalizedValue);
    }
}
