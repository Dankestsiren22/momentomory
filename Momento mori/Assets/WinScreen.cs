using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public EnemyAi boss;
    void Update()
    {
        if (boss.CurrentHealth == 0)
        {
            SceneManager.LoadScene(9);
        }
    }
}
