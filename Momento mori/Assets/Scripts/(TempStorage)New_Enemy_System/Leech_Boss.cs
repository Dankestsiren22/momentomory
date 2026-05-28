using UnityEngine;

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
    public int Chosen_Attack = 0;
    private int Starting_Wait = 1;
    public void FixedUpdate()
    {
        
    }

    public void Choose_Attack()
    {
        Chosen_Attack = Random.Range(1, 2);
        animator.SetInteger("Attack_Sequence", Chosen_Attack);
        Chosen_Attack = 0;
    }
}
