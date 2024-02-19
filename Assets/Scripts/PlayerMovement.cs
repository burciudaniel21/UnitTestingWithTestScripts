using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rotationSpeed = 180f;
    private float jumpForce = 10f;

    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference rotateLeftAction;
    [SerializeField] private InputActionReference rotateRightAction;
    [SerializeField] private InputActionReference jumpAction;

    // Public fields for testing purposes
    public Rigidbody rb;
    public Vector2 moveInput;
    public bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        moveAction.action.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.action.canceled += ctx => moveInput = Vector2.zero;

        jumpAction.action.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        rotateLeftAction.action.Enable();
        rotateRightAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        rotateLeftAction.action.Disable();
        rotateRightAction.action.Disable();
        jumpAction.action.Disable();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        Vector3 moveDirection = new Vector3(0f, 0f, moveInput.y);
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.fixedDeltaTime);
    }

    public void Rotate()
    {
        float rotationInput = rotateRightAction.action.ReadValue<float>() - rotateLeftAction.action.ReadValue<float>();
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}