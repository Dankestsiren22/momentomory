using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    Controls controls;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        controls = new Controls();
        controls.Player.ParrySelect.started += _ => SceneManager.LoadScene(2);
        controls.Player.PauseInventory.started += _ => SceneManager.LoadScene(0);
    }
}
