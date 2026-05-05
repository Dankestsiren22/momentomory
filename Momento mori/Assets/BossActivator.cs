using UnityEngine;
using UnityEngine.UI;

public class BossActivator : MonoBehaviour
{
    public GameObject Doctor;
    public PlayerMovement Player;
    private void Start()
    {
        Doctor.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Doctor.SetActive(true);
            Player.IsPaused = true;
        }
    }
}
