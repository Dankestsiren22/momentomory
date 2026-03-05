using Unity.VisualScripting;
using UnityEngine;

public class TestParryBall : MonoBehaviour
{
    Rigidbody2D rb;
    public bool Parryed;
    public GameObject explosin;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, -5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ActiveParry"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            GameObject p = Instantiate(explosin, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(p, .5f);

        }
        
    }


}
