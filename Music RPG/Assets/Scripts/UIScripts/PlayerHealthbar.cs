using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Image fill;
    public Gradient healthGradient;
    //public PlayerStats playerStats;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxHealth(Stats.Instance.MaxHealth);
    }

    private void Update()
    {
        SetHealth(Stats.Instance.Health);
    }

    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    private void SetHealth(double health)
    {
        slider.value = (float)health;

        fill.color = healthGradient.Evaluate(slider.normalizedValue);
    }
}

