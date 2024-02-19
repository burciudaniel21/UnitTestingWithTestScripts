using NUnit.Framework;
using UnityEngine;

public class PlayerMovementTests
{
    [Test]
    public void Move_Forwards()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        PlayerMovement playerMovement = gameObject.AddComponent<PlayerMovement>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        playerMovement.rb = rb;

        // Act
        playerMovement.moveInput = new Vector2(0f, 1f);
        playerMovement.Move();

        // Assert
        Assert.IsTrue(rb.position.z > 0); // Check if position.z increased
    }

    [Test]
    public void Move_Backwards()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        PlayerMovement playerMovement = gameObject.AddComponent<PlayerMovement>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        playerMovement.rb = rb;

        // Act
        playerMovement.moveInput = new Vector2(0f, -1f);
        playerMovement.Move();

        // Assert
        Assert.IsTrue(rb.position.z < 0); // Check if position.z decreased
    }

    [Test]
    public void Jump()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        PlayerMovement playerMovement = gameObject.AddComponent<PlayerMovement>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        playerMovement.rb = rb;
        playerMovement.isGrounded = true; // Ensure the player is initially grounded

        // Act
        playerMovement.Jump();

        // Assert
        Assert.IsTrue(!playerMovement.isGrounded); // Check if the player is no longer grounded after jumping
    }

}
