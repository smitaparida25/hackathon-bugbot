using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The character to follow
    public Vector3 offset;   // Offset from the target
    public float smoothSpeed = 0.125f; // Speed of camera smoothing

    void LateUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = target.position + offset;
        // Smoothly interpolate between the current position and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Set the camera position
        transform.position = smoothedPosition;

        // Optional: Make the camera look at the target
        transform.LookAt(target);
    }
}
