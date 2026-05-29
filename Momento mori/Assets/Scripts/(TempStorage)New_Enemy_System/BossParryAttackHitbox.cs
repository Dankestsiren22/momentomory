using System.Collections;
using UnityEngine;

public class BossParryAttackHitbox : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite warningSprite;
    public Sprite attackSprite;
    public Collider2D hitboxCollider;
    public IDamageable boss;
    public float warningTime = 0.5f;
    public float activeTime = 0.2f;
    public int Damage = 1;
    void Start()
    {
        StartCoroutine(attackRoutine());
    }

    IEnumerator attackRoutine()
    {
        hitboxCollider.enabled = false;
        spriteRenderer.sprite = warningSprite;
        Color color = spriteRenderer.color;
        color.a = 0.4f;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(warningTime);
        spriteRenderer.sprite = attackSprite;
        color.a = 1f;
        spriteRenderer.color = color;
        hitboxCollider.enabled = true;
        yield return new WaitForSeconds(activeTime);
        hitboxCollider.enabled = false;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        IParryable parryable = collision.GetComponent<IParryable>();
        if (parryable != null && parryable.IsParrying == true)
        {
            boss.Damage(Damage);
            return;
        }
        else if (damageable != null)
        {
            damageable.Damage(Damage);
        }
    }
}
