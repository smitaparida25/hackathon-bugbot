using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;  // Reference to the CharacterController component
    public Animator animator;               // Reference to the Animator component
    public float walkSpeed = 2f;            // Walking speed
    public float runSpeed = 5f;             // Running speed
    public float gravity = -9.81f;          // Gravity value
    public float jumpHeight = 1.5f;         // Jump height

    private Vector3 velocity;
    private bool isGrounded;
    public Transform groundCheck;           // Transform for checking if the player is grounded
    public float groundDistance = 0.4f;     // Radius for checking ground contact
    public LayerMask groundMask;            // Mask to define what is considered ground

    void Update()
    {
        // Ground check to see if the player is touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small negative value to keep the player grounded
        }

        // Capture input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Determine speed based on whether the run key is pressed
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Move the player
        controller.Move(move * speed * Time.deltaTime);

        // Update the Speed parameter in the Animator based on player movement
        float magnitude = new Vector3(moveX, 0, moveZ).magnitude;
        animator.SetFloat("Speed", magnitude * speed);

        // Jump logic - Check if the jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }

        // Apply gravity to the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
