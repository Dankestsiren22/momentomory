using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement: MonoBehaviour
{
    public void LoadLevel(int x)
    {
        SceneManager.LoadScene(x);


    }

}
