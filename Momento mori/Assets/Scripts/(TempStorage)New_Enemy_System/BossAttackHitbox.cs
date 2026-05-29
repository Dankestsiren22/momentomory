using System.Collections;
using UnityEngine;

public class BossAttackHitbox : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite warningSprite;
    public Sprite attackSprite;
    public Collider2D hitboxCollider;
    public float warningTime = 0.5f;
    public float activeTime = 0.2f;
    public int damage = 1;
    void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
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
        if (damageable != null)
        {
            damageable.Damage(damage);
        }
    }
}