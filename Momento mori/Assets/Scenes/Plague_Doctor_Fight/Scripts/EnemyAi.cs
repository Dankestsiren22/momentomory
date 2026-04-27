using UnityEngine;
using System.Collections;
public class EnemyAi : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public int AttackCoolDown;

    public GameObject[] MoveList;
    public Sequence[] AttackSequences;
    public AudioClip[] audioClips;

    public Animator animator;


    //----------------------------------------------\\
    public void Awake()
    {
        
    }

    public void FixedUpdate()
    {
        while (AttackCoolDown > 0)
        {
            AttackCoolDown--;
            
        }
    }
    public void Attack()
    {

    }
 
}
