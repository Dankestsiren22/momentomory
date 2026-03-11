using UnityEngine;
using System.Collections;

public class CombatMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Controls controls;
    public bool IsDead;
    public int Speed;
    public float UD_Movement;
    public float LR_Movement;
    Canvas DeathMenu;
    
    public bool CanParry;
    public float parryWindow;
    public int DamageDelt;

    public int health;
    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new Controls();
        CanParry = true;
        controls.Player.UDFB_Movement.performed += ctx => UD_Movement = ctx.ReadValue<float>();
        controls.Player.UDFB_Movement.canceled += _ => UD_Movement = 0;
        DeathMenu = GameObject.Find("DeathCanvas").GetComponent<Canvas>();
        controls.Player.TurningLR_Movement.performed += ctx => LR_Movement = ctx.ReadValue<float>();
        controls.Player.TurningLR_Movement.canceled += _ => LR_Movement = 0;

        controls.Player.ParrySelect.started += _ => parry();
        DeathMenu.enabled = false;
        IsDead = false;
    }
    void FixedUpdate()
    {
        Vector2 input = new Vector2(LR_Movement, UD_Movement); 
        if (input.sqrMagnitude > 1)
            input = input.normalized;
        rb.linearVelocity = input * Speed;
    }
    private void Update()
    {
        if (health <= 0)
        {
            IsDead = true;
        }
        if (IsDead == true)
        {
            DeathMenu.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void parry()
    {
        if (CanParry == true)
        {
            transform.gameObject.tag = "ActiveParry";
            CanParry = false;
            StartCoroutine(ParryWindow());
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.gameObject.tag == "ActiveParry" & other.CompareTag("ParryableAttack"))
        {
            CanParry = true;
            transform.gameObject.tag = "Player";
            DamageDelt++;
        }
        
        if (other.CompareTag("Explosin"))
        {
            health--;
        }
    }

    IEnumerator ParryWindow()
    {
        yield return new WaitForSeconds(parryWindow);
        gameObject.tag = "Player";
    }



}
