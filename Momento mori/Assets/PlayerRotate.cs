using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Camera mainCamera;
    public float rotationSpeed = 10f; 
    private void LateUpdate()
    {
        
        RotatePlayerTowardsCamera();
    }

    private void RotatePlayerTowardsCamera()
    {
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0f; 

            if (cameraForward != Vector3.zero)
            {

                Quaternion targetRotation = Quaternion.LookRotation(cameraForward, Vector3.up);


                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}

