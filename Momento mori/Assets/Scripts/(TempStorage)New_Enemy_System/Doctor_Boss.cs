using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Docotr_Boss : MonoBehaviour, IDamageable
{
    public enum DoctorStates
    {
        Idle,
        Choosing,
        Attacking
    }
    public enum DoctorAttacks
    {
        DoubleSwipe = 1,
        SwipeStraight = 2,
        SwipeReverse = 3,
    }
    [System.Serializable]
    public class WeightedAttack
    {
        public DoctorAttacks attack;
        [Header("Starting Chance")]
        public int baseWeight = 50;
        [HideInInspector]
        public int currentWeight;
    }
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
    public DoctorStates currentState;
    private DoctorAttacks chosenAttack;
    public GameObject SwipePrefab;
    public GameObject StraightPrefab;
    public GameObject ReversePrefab;
    public Transform Player;
    [Header("Weighted Attacks")]
    public List<WeightedAttack> attacks = new List<WeightedAttack>()
    {
        new WeightedAttack { attack = DoctorAttacks.DoubleSwipe, baseWeight = 70 },
        new WeightedAttack { attack = DoctorAttacks.SwipeStraight, baseWeight = 20 },
    };
    void Start()
    {
        currentState = DoctorStates.Idle;
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
            case DoctorStates.Idle:

                HandleIdle();
                break;

            case DoctorStates.Choosing:
                ChooseAttack();
                break;

            case DoctorStates.Attacking:
                PerformAttack();
                break;
        }
    }
    void HandleIdle()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            ChangeState(DoctorStates.Choosing);
        }
    }
    void ChooseAttack()
    {
        chosenAttack = GetWeightedAttack();
        Debug.Log("Chosen Attack: " + chosenAttack);
        ChangeState(DoctorStates.Attacking);
    }
    void PerformAttack()
    {
        animator.SetInteger("Attack_Sequence", (int)chosenAttack);
        cooldownTimer = attackCooldown;
        ChangeState(DoctorStates.Idle);
    }
    DoctorAttacks GetWeightedAttack()
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
        return DoctorAttacks.DoubleSwipe;
    }
    public void ChangeState(DoctorStates newState)
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
        GameObject p = Instantiate(StraightPrefab);
        BossParryAttackHitbox attack = p.GetComponent<BossParryAttackHitbox>();
        attack.boss = this;
    }
    public void SpawnReverse()
    {
        Instantiate(ReversePrefab);
    }
    public void Die()
    {
        SceneManager.LoadScene(9);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}