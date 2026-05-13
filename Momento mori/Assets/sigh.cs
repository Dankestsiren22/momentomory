using UnityEngine;
using UnityEngine.SceneManagement;

public class sigh : MonoBehaviour
{
    Controls controls;

    private void Awake()
    {
        controls = new Controls();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Quit.started += _ => Application.Quit();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Player.Quit.started -= _ => Application.Quit();
    }
}
