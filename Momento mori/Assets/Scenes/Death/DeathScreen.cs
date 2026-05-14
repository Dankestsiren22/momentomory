using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject player;
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
        controls.Player.ParrySelect.started += _ => retry();
        controls.Player.PauseInventory.started += _ => SceneManager.LoadScene(0);
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
