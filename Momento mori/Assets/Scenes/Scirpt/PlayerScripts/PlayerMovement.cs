using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Controls controls;
    public CharacterController Controller;


    public GameObject PauseMenu;

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
        PauseMenu.SetActive(false);
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
            PauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if ( IsPaused == false)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    
}
