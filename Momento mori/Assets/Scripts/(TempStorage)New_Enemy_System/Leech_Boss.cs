using System.Collections.Generic;
using UnityEngine;
public enum LeechStates
{
    Idle,
    Choosing,
    Attacking
}
public enum BossAttack
{
    DoubleSwipe = 1,
    SwipeStraight = 2,
}
[System.Serializable]
public class WeightedAttack
{
    public BossAttack attack;
    [Header("Starting Chance")]
    public int baseWeight = 50;
    [HideInInspector]
    public int currentWeight;
}
public class Leech_Boss : MonoBehaviour, IDamageable
{
    public HealthBar healthBar { get; private set; }
    public GameObject Parry_Box { get; private set; }
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
    public void Parried()
    {
        Damage(1);
    }
    [Header("Boss Settings")]
    public Animator animator;
    public float attackCooldown = 3f;
    private float cooldownTimer;
    public LeechStates currentState;
    private BossAttack chosenAttack;
    public GameObject SwipePrefab;
    public GameObject StraightPrefab;
    public Transform Player;
    [Header("Weighted Attacks")]
    public List<WeightedAttack> attacks = new List<WeightedAttack>()
    {
        new WeightedAttack { attack = BossAttack.DoubleSwipe, baseWeight = 70 },
        new WeightedAttack { attack = BossAttack.SwipeStraight, baseWeight = 20 },
    };
    void Start()
    {
        currentState = LeechStates.Idle;
        cooldownTimer = attackCooldown;
        foreach (WeightedAttack attack in attacks)
        {
            attack.currentWeight = attack.baseWeight;
        }
        healthBar = GetComponent<HealthBar>();
    }
    void Update()
    {
        switch (currentState)
        {
            case LeechStates.Idle:

                HandleIdle();
                break;

            case LeechStates.Choosing:
                ChooseAttack();
                break;

            case LeechStates.Attacking:
                PerformAttack();
                break;
        }
    }
    void HandleIdle()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            ChangeState(LeechStates.Choosing);
        }
    }
    void ChooseAttack()
    {
        chosenAttack = GetWeightedAttack();
        Debug.Log("Chosen Attack: " + chosenAttack);
        ChangeState(LeechStates.Attacking);
    }
    void PerformAttack()
    {
        animator.SetInteger("Attack_Sequence", (int)chosenAttack);
        cooldownTimer = attackCooldown;
        ChangeState(LeechStates.Idle);
    }
    BossAttack GetWeightedAttack()
    {
        int totalWeight = 0;
        foreach (WeightedAttack attack in attacks)
        {
            totalWeight += attack.currentWeight;
        }
        int randomNumber = Random.Range(0, totalWeight);
        int currentWeight = 0;
        foreach (WeightedAttack attack in attacks)
        {
            currentWeight += attack.currentWeight;
            if (randomNumber < currentWeight)
            {
                attack.currentWeight = Mathf.Max(1, attack.currentWeight / 2);
                foreach (WeightedAttack otherAttack in attacks)
                {
                    if (otherAttack != attack)
                    {
                        otherAttack.currentWeight += 5;
                        if (otherAttack.currentWeight > otherAttack.baseWeight)
                        {
                            otherAttack.currentWeight = otherAttack.baseWeight;
                        }
                    }
                }
                return attack.attack;
            }
        }
        return BossAttack.DoubleSwipe;
    }
    public void ChangeState(LeechStates newState)
    {
        currentState = newState;
    }
    public void SpawnSwipe()
    {
        Instantiate(SwipePrefab, Player.position, Quaternion.identity);
    }
    public void SpawnStraight()
    {
        Debug.Log("CalledStraight");
        GameObject p = Instantiate(StraightPrefab, Player.position, Quaternion.identity);
        BossParryAttackHitbox attack = p.GetComponent<BossParryAttackHitbox>();
        attack.boss = this;
    }
    public void Die()
    {

    }
}