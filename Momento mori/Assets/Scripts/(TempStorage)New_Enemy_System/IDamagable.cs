using UnityEngine;

public interface IDamageable
{
    HealthBar healthBar { get; }
    int MaxHealth { get; }
    int CurrentHealth { get; }
    void Damage(int Amount);
    void Die();
}
