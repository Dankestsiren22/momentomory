using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Controls controls;
    Rigidbody rb;

    float verticalMove;
    float horizontalMove;

    public Canvas PauseMenu;

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
        rb = GetComponent<Rigidbody>();
        controls.Player.UDFB_Movement.performed += ctx => FBmovment = ctx.ReadValue<float>();
        controls.Player.UDFB_Movement.canceled += _ => FBmovment = 0;

        controls.Player.TurningLR_Movement.performed += ctx => Rotation = ctx.ReadValue<float>();
        controls.Player.TurningLR_Movement.canceled += _ => Rotation = 0;

        controls.Player.PauseInventory.started += _ => Pause();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PauseMenu.enabled = false;
    }

    public void Update()
    {
        Vector3 temp = rb.linearVelocity;
        temp.x = FBmovment * speed;
        rb.linearVelocity = (temp.x * transform.forward);
        if (!IsPaused) 
            transform.Rotate(0f, (RotateSpeed * Rotation), 0f);
    }
   
    public void Pause()
    {
        IsPaused = !IsPaused;
        if(IsPaused == true)
        {
            Time.timeScale = 0;
            PauseMenu.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if ( IsPaused == false)
        {
            Time.timeScale = 1;
            PauseMenu.enabled = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
