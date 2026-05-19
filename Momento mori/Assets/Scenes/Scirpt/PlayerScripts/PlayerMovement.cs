using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Controls controls;
    public CharacterController Controller;
    public PlayerData data;

    public Canvas PauseMenu;

    public int MaxMementos = 3;
    public int CurrentMementos;
    public bool IsPaused;

    public float FBmovment;
    public float Rotation;
    public float speed;
    public float RotateSpeed;

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
    public void Awake()
    {
        
        controls = new Controls();
        controls.Player.UDFB_Movement.performed += ctx => FBmovment = ctx.ReadValue<float>();
        controls.Player.UDFB_Movement.canceled += _ => FBmovment = 0;
        controls.Player.TurningLR_Movement.performed += ctx => Rotation = ctx.ReadValue<float>();
        controls.Player.TurningLR_Movement.canceled += _ => Rotation = 0;
        controls.Player.PauseInventory.started += _ => Pause();
        PauseMenu.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (!IsPaused)
        {
            transform.Rotate(0f, (RotateSpeed * Rotation), 0f);

            Vector3 moveDirection = transform.forward * FBmovment * speed;

            Controller.SimpleMove(moveDirection);
        }
    }
   
    public void Pause()
    {
        IsPaused = !IsPaused;
        if(IsPaused == true)
        {
            Time.timeScale = 0;
            PauseMenu.enabled = (true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if ( IsPaused == false)
        {
            Time.timeScale = 1;
            PauseMenu.enabled = (false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Memento")
        {
            
            memento();
            data.SavePlayer();
            
        }

        if (other.tag == "Elimination Area")
        {
            SceneManager.LoadScene(7);
        }
    }
    public void memento()
    {
        if (data.Memento1 == false)
            data.Memento1 = true;
        else if (data.Memento2 == false)
            data.Memento2 = true;
        else if (data.Memento3 == false)
            data.Memento3 = true;
        else if (data.Memento4 == false)
            data.Memento4 = true;
    }
}
