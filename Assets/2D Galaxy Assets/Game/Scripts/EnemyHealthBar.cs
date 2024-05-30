using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Health health;

    void Start()
    {
        
        health.onHealthChanged.AddListener(UpdateHealthBar);

    }

    void UpdateHealthBar()
    {
        healthSlider.value = health.GetCurrentHealth();
    }
}
