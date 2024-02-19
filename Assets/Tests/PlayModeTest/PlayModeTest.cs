using NUnit.Framework;
using UnityEngine;

public class PlayModeTest
{
    [Test]
    public void PlayerTakesDamage()
    {
        GameObject playerObject = new GameObject("Player");
        PlayerHealth playerHealth = playerObject.AddComponent<PlayerHealth>();

        playerHealth.SetupInitialHealth();
        playerHealth.TakeDamage(20);

        Assert.AreEqual(80, playerHealth.currentHealth);
    }

    [Test]
    public void PlayerDiesWhenHealthZero()
    {
        GameObject playerObject = new GameObject("Player");
        PlayerHealth playerHealth = playerObject.AddComponent<PlayerHealth>();

        // Simulate player taking damage until health reaches zero
        playerHealth.TakeDamage(100);

        Assert.AreEqual(0, playerHealth.currentHealth);
        // Add additional assertions or checks as needed for your specific case
    }

    [Test]
    public void InitialHealthIsSetup()
    {
        GameObject playerObject = new GameObject("Player");
        PlayerHealth playerHealth = playerObject.AddComponent<PlayerHealth>();

        playerHealth.SetupInitialHealth();

        Assert.AreEqual(100, playerHealth.currentHealth);
    }
}
