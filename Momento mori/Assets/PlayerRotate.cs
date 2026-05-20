using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Camera mainCamera;
    public float rotationSpeed = 10f; // Adjust to control how fast the player turns

    private void LateUpdate()
    {
        // Rotate the player towards the camera every frame 
        RotatePlayerTowardsCamera();
    }

    private void RotatePlayerTowardsCamera()
    {
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0f; // Ignore the y-axis rotation 

            if (cameraForward != Vector3.zero)
            {
                // Fix 1: Added Vector3.up as the second parameter to stabilize rotation
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward, Vector3.up);

                // Fix 2: Smooth the rotation instead of snapping instantly
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}

