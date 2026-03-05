using UnityEngine;

public class CombatMovement : MonoBehaviour
{
    public int Speed;
    public float UD_Movement;
    public float LR_Movement;
    Rigidbody2D rb;
    Controls controls;

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new Controls();
        controls.Player.UDFB_Movement.performed += ctx => UD_Movement = ctx.ReadValue<float>();
        controls.Player.UDFB_Movement.canceled += _ => UD_Movement = 0;

        controls.Player.TurningLR_Movement.performed += ctx => LR_Movement = ctx.ReadValue<float>();
        controls.Player.TurningLR_Movement.canceled += _ => LR_Movement = 0;
    }
    void Update()
    {
        Vector2 input = new Vector2(LR_Movement, UD_Movement); 
        if (input.sqrMagnitude > 1)
            input = input.normalized;
        rb.linearVelocity = input * Speed;
    }
}
