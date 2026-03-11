using Unity.VisualScripting;
using UnityEngine;

public class TestParryBall : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject Player;
    public bool Parryed;
    public GameObject explosin;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
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
            GameObject p = Instantiate(explosin, Player.transform.position, Player.transform.rotation);
            Destroy(gameObject);
            Destroy(p, .5f);

        }
        
    }


}
