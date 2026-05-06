using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    int y = 1;
    private void OnEnable()
    {
        controls.Enable();
    } 
    private void OnDisable()
    {
        controls.Disable();
    }
    Controls controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        controls = new Controls();
        controls.Player.ParrySelect.started += _ => NextLevel(y);
    }

    public void NextLevel(int x)
    {
        if (y == 2)
            Destroy(gameObject);
        SceneManager.LoadScene(x);
        y++;
        
    }
}
