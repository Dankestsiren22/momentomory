using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement: MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void lobby()
    {
        SceneManager.LoadScene(1);
    }

    public void PlagueDoctor()
    {
        SceneManager.LoadScene(3);
    }
}
