using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CombatMovement : MonoBehaviour, IDamageable, IParryable
{
    public HealthBar healthBar { get; private set; }
    public int MaxHealth { get; private set; } = 10;
    public int CurrentHealth { get; private set; } = 10;

    public void Damage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Boss Dead");
        }
        if (healthBar != null)
            healthBar.SetHealth(CurrentHealth, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(7);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public bool IsParrying { get; private set; }

    public void StartParry()
    {
        IsParrying = true;
    }
    void EndParry()
    {
        IsParrying = false;
    }

    Rigidbody2D rb;
    Controls controls;
    Animator animator;
    public Canvas PauseMenu;

    
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

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
            animator.SetTrigger("Parry");
            CanParry = false;
            IsParrying = true;
            StartCoroutine(ParryCooldown());
        }
    }
    
    IEnumerator ParryCooldown()
    {
        yield return new WaitForSeconds(parrycooldown);
        CanParry = true;
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
