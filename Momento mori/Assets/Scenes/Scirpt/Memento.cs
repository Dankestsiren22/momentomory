using UnityEngine;
using UnityEngine.SceneManagement;


public class Memento : MonoBehaviour
{
    private Transform cameraTransform;
    public int SceneIndex;
    private void Awake()
    {
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }
    private void LateUpdate()
    {
        if (cameraTransform  != null)
        {
            transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
        }
    }
    public void Scence()
    {
        SceneManager.LoadScene(SceneIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Scence();
        }

    }
}
