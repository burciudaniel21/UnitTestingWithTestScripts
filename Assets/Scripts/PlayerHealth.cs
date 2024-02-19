using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        SetupInitialHealth();
    }

    public void SetupInitialHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Ensure health doesn't go below zero
        currentHealth = Mathf.Max(0, currentHealth - damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death
        Debug.Log("Player has died!");
    }
}
