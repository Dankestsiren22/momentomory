using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
public class EnemyAi : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public int AttackCoolDown;

    public GameObject[] MoveList;
    public List<Sequence> AttackSequences;
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
