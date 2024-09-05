using UnityEngine;
using UnityEngine.UI;

public class StatusBarController : MonoBehaviour
{
    public Image healthBarForeground; // The Image component for the foreground of the health bar
    public Image hydrationBarForeground; // The Image component for the foreground of the hydration bar

    public float maxHealth = 100f; // Maximum health value
    public float maxHydration = 100f; // Maximum hydration value

    private float currentHealth; // Current health value
    private float currentHydration; // Current hydration value

    void Start()
    {
        // Initialize current values to max values
        currentHealth = maxHealth;
        currentHydration = maxHydration;

        // Set up the health and hydration bars
        SetupBar(healthBarForeground);
        SetupBar(hydrationBarForeground);

        // Update the bars initially
        UpdateHealthBar();
        UpdateHydrationBar();
    }

    void Update()
    {
        // Example logic to decrease health and hydration for testing purposes
        // Replace these with your actual game logic
        if (Input.GetKey(KeyCode.H)) // Press 'H' to simulate health decrease
        {
            TakeDamage(10f * Time.deltaTime); // Decrease health over time
        }
        
        if (Input.GetKey(KeyCode.J)) // Press 'J' to simulate hydration decrease
        {
            ConsumeHydration(5f * Time.deltaTime); // Decrease hydration over time
        }
    }

    public void TakeDamage(float amount)
    {
        // Reduce current health and clamp it to ensure it doesn't go below zero
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar(); // Update the health bar whenever health changes
    }

    public void ConsumeHydration(float amount)
    {
        // Reduce current hydration and clamp it to ensure it doesn't go below zero
        currentHydration -= amount;
        currentHydration = Mathf.Clamp(currentHydration, 0f, maxHydration);
        UpdateHydrationBar(); // Update the hydration bar whenever hydration changes
    }

    private void SetupBar(Image bar)
    {
        if (bar != null)
        {
            // Ensure the Image component is set to fill
            bar.type = Image.Type.Filled;
            bar.fillMethod = Image.FillMethod.Horizontal; // Set to Horizontal or Vertical based on design
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarForeground != null)
        {
            // Update the fill amount of the health bar foreground image based on current health
            healthBarForeground.fillAmount = currentHealth / maxHealth;
        }
    }

    private void UpdateHydrationBar()
    {
        if (hydrationBarForeground != null)
        {
            // Update the fill amount of the hydration bar foreground image based on current hydration
            hydrationBarForeground.fillAmount = currentHydration / maxHydration;
        }
    }
}
