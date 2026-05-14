using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public EnemyAi boss;
    public int Level;
    void Update()
    {
        if (boss.CurrentHealth == 0)
        {
            SceneManager.LoadScene(Level);
        }
    }
}
