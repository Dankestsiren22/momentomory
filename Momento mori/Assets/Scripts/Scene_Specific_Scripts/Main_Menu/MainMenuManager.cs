using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    public void Stop()
    {
        Application.Quit();
    }
}
