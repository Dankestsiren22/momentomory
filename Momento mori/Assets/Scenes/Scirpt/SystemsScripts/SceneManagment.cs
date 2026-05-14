using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement: MonoBehaviour
{
    public PlayerData data;
    public void LoadLevel(int x)
    {
        SceneManager.LoadScene(x);


    }
    public void retry()
    {
        data.Memento1 = false;
        data.Memento2 = false;
        data.Memento3 = false;
        data.Memento4 = false;
        data.SavePlayer();
        SceneManager.LoadScene(2);
    }
}
