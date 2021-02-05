using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialMeter : MonoBehaviour
{
    public Gradient comboGradient;
    public Image fill;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxCombo(Stats.Instance.MaxCombo);
    }

    private void Update()
    {
        SetCombo(Stats.Instance.Combo);
    }

    private void SetMaxCombo(int combo)
    {
        slider.maxValue = combo;
    }

    private void SetCombo(int combo)
    {
        slider.value = combo;

        fill.color = comboGradient.Evaluate(slider.normalizedValue);
    }
}
