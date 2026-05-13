using UnityEngine;
using UnityEngine.SceneManagement;

public class sigh : MonoBehaviour
{
    Controls controls;
    
    private void OnEnable() => controls.Enable();
    private void OnDisable()
    {
        controls.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        controls.Player.Quit.started += _ => Application.Quit();
    }
}
