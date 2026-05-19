using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CombatMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Controls controls;
    Animator animator;
    public Canvas PauseMenu;

    public int MaxHealth;
    public int Health;
    public int Speed;

    public float UD_Movement;
    public float LR_Movement;
    
    public bool CanParry;
    public float parryWindow;
    public float parrycooldown;
    public bool IsPaused;

    private void OnEnable() => controls.Enable();
    private void OnDisable()
    {
        controls.Disable();
    }

    public void Awake()
    {

        animator = GetComponent<Animator>();



        rb = GetComponent<Rigidbody2D>();
        controls = new Controls();
        CanParry = true;
        controls.Player.UDFB_Movement.performed += ctx => UD_Movement = ctx.ReadValue<float>();
        controls.Player.UDFB_Movement.canceled += _ => UD_Movement = 0;

        controls.Player.TurningLR_Movement.performed += ctx => LR_Movement = ctx.ReadValue<float>();
        controls.Player.TurningLR_Movement.canceled += _ => LR_Movement = 0;

        controls.Player.PauseInventory.started += _ => pause();

        controls.Player.ParrySelect.started += _ => parry();

        PauseMenu.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        Vector2 input = new Vector2(LR_Movement, UD_Movement); 
        if (input.sqrMagnitude > 1)
            input = input.normalized;
        rb.linearVelocity = input * Speed;
    }
    public void parry()
    {
        if (CanParry == true)
        {
            CanParry = false;
            transform.gameObject.tag = "ActiveParry";
            StartCoroutine(ParryWindow());
            StartCoroutine(ParryCooldown());
            animator.SetTrigger("Parry");
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.gameObject.tag == "ActiveParry" & other.CompareTag("ParryableAttack"))
        {

            CanParry = true;
            transform.gameObject.tag = "Player";
        }
        else if (other.tag == "ParryableAttack")
        {
            Health = Health - 2;
        }
        else if (other.tag == "Unparryable")
        {
            Health--; 
        }
    }

    IEnumerator ParryWindow()
    {
        yield return new WaitForSeconds(parryWindow);
        gameObject.tag = "Player";
    }
    IEnumerator ParryCooldown()
    {
        yield return new WaitForSeconds(parrycooldown);
        CanParry = true;
    }


    private void Update()
    {
        if (Health == 0)
        {
            SceneManager.LoadScene(7);
        }


    }

    public void pause()
    {
        IsPaused = !IsPaused;
        if (IsPaused == true)
        {
            Time.timeScale = 0;
            PauseMenu.enabled = (true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (IsPaused == false)
        {
            Time.timeScale = 1;
            PauseMenu.enabled = (false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
