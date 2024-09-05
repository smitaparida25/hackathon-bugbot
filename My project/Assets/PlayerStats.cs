using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Image healthBarForeground;
    public Image hydrationBarForeground;
    
    public float health = 100f;
    public float hydration = 100f;
    public float healthDecreaseRate = 1f;  // Health decrease per second
    public float hydrationDecreaseRate = 1f;  // Hydration decrease per second

    private float maxHealth = 100f;
    private float maxHydration = 100f;

    void Start()
    {
        // Initialize bar sizes
        UpdateBars();
    }

    void Update()
    {
        // Simulate health and hydration decrease over time
        health -= healthDecreaseRate * Time.deltaTime;
        hydration -= hydrationDecreaseRate * Time.deltaTime;

        // Clamp values to ensure they don't go below 0
        health = Mathf.Clamp(health, 0f, maxHealth);
        hydration = Mathf.Clamp(hydration, 0f, maxHydration);

        // Update UI bars
        UpdateBars();
    }

    void UpdateBars()
    {
        // Update health bar
        float healthFillAmount = health / maxHealth;
        healthBarForeground.fillAmount = healthFillAmount;

        // Update hydration bar
        float hydrationFillAmount = hydration / maxHydration;
        hydrationBarForeground.fillAmount = hydrationFillAmount;
    }
}
