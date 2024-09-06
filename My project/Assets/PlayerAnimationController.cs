using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to Animator component
    public float speed;       // Speed parameter for movement

    void Update()
    {
        // Get input values
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate speed and update Animator
        float moveSpeed = new Vector3(moveX, 0, moveZ).magnitude;
        animator.SetFloat("Speed", moveSpeed);

        // Handle jumping (assuming you have a Jump trigger)
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }
    }
}
