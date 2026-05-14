using UnityEngine;
using UnityEngine.SceneManagement;

public class good : MonoBehaviour
{
    public PlayerData data;
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    Controls controls;
    void Awake()
    {
        controls = new Controls();
        controls.Player.PauseInventory.started += _ =>
        {
            SceneManager.LoadScene(0);
            data.Memento1 = false;
            data.Memento2 = false;
            data.Memento3 = false;
            data.Memento4 = false;
            data.SavePlayer();
        };
    }
}
