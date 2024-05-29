using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Health  health;
    public Slider healthSlider;

    void Start()
    {
        healthSlider.maxValue = health.GetMaxHealth();
        healthSlider.value = health.GetCurrentHealth();
        health.onHealthChanged.AddListener(UpdateHealthBar);
    }

    void UpdateHealthBar()
    {
        healthSlider.value = health.GetCurrentHealth();
    }
}
