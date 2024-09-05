using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image healthBarForeground;
    public Image hydrationBarForeground;

    public float maxHealth = 100f;
    public float maxHydration = 100f;

    private float currentHealth;
    private float currentHydration;

    void Start()
    {
        currentHealth = maxHealth;
        currentHydration = maxHydration;
        UpdateHealthBar();
        UpdateHydrationBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void UseHydration(float amount)
    {
        currentHydration -= amount;
        if (currentHydration < 0) currentHydration = 0;
        UpdateHydrationBar();
    }

    public void RefillHydration(float amount)
    {
        currentHydration += amount;
        if (currentHydration > maxHydration) currentHydration = maxHydration;
        UpdateHydrationBar();
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthBarForeground.fillAmount = healthPercentage;
    }

    private void UpdateHydrationBar()
    {
        float hydrationPercentage = currentHydration / maxHydration;
        hydrationBarForeground.fillAmount = hydrationPercentage;
    }
}
