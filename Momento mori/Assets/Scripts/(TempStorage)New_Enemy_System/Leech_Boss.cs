using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public enum LeechStates
{
    Idle,
    choosing,
    attacking,



}
public class Leech_Boss : MonoBehaviour, IDamageable, IParryable
{
    public GameObject Parry_Box { get; private set; }
    public int Health { get; private set; } = 1;
    public void Damage(int amount)
    {
        Health = -amount;
    }
    public void Parried()
    {
        Damage(1);
    }


    public Animator animator;
    public float Cooldown;
    public int Chosen_Attack = 0;
    private int Starting_Wait = 1;
    public LeechStates currentState;
    public int Attacked;
    public void Start()
    {
        currentState = LeechStates.Idle;
    }
    public void FixedUpdate()
    {
        switch(currentState)
        {
            case LeechStates.Idle:
                StartCoroutine(CoolDown(1));
                Chosen_Attack = 0;
                animator.SetInteger("Attack_Sequence", Chosen_Attack);
                if (Cooldown <= 0)
                {
                    ChangeState(LeechStates.choosing);
                }
                break;
            case LeechStates.choosing:
                Chosen_Attack = Random.Range(1, 2);
                break;
            case LeechStates.attacking:
                animator.SetInteger("Attack_Sequence", Chosen_Attack);
                StartCoroutine(ReturnToIdle());
                break;
            default:
                StartCoroutine(CoolDown(1));
                Chosen_Attack = 0;
                animator.SetInteger("Attack_Sequence", Chosen_Attack);
                break;
        }
    }

    public void Choose_Attack()
    {
        Chosen_Attack = Random.Range(1, 2);
        animator.SetInteger("Attack_Sequence", Chosen_Attack);
        StartCoroutine(ReturnToIdle());
    }
    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(1);
        Chosen_Attack = 0;
        animator.SetInteger("Attack_Sequence", Chosen_Attack);
    }
    IEnumerator CoolDown(float x)
    {
        yield return new WaitForSeconds(x);
        Cooldown = 0;
    }
    public void ChangeState(LeechStates NewState)
    {
        currentState = NewState;
    }
    public void attacked()
    {
        Attacked++;
    }
}
