using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAi : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public float AttackCoolDown;
    public Animator animator;
    public AudioSource audioSource;
    public List<Sequence> AttackSequences;
    private bool isAttacking = false;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Attack()
    {
        if (isAttacking) return;
        if (AttackSequences == null || AttackSequences.Count == 0) return;

        Sequence chosenSequence = AttackSequences[Random.Range(0, AttackSequences.Count)];
        StartCoroutine(PlaySequence(chosenSequence));
    }

    IEnumerator PlaySequence(Sequence sequence)
    {
        isAttacking = true;
        foreach (Block block in sequence.Blocks)
        {
            if (animator != null && !string.IsNullOrEmpty(block.AnimationName))
            {
                animator.Play(block.AnimationName);
            }

            if (block.Sound != null)
            {
                if (audioSource != null)
                    audioSource.PlayOneShot(block.Sound);
                else
                    AudioSource.PlayClipAtPoint(block.Sound, transform.position);
            }
            yield return new WaitForSeconds(block.AnimationLength + .1f);
        }
        yield return new WaitForSeconds(AttackCoolDown);
        isAttacking = false;
    }
}