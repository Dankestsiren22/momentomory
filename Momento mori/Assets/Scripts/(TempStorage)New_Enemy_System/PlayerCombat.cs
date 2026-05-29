using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable, IParryable
{
    public HealthBar healthBar { get; private set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public void Damage(int Amount)
    {
        CurrentHealth -= Amount;
        if (healthBar != null)
            healthBar.SetHealth(CurrentHealth, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        
    }
    public bool IsParrying { get; private set; }
}
