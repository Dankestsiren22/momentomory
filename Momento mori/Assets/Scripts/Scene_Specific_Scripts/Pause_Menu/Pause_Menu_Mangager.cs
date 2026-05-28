using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Mangager : MonoBehaviour
{
    public void LoadLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
