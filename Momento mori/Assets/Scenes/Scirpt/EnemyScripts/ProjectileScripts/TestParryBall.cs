using Unity.VisualScripting;
using UnityEngine;

public class TestParryBall : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject Player;
    public int speed;
    public Vector3 destenation;
    public bool Parryed;
    public GameObject explosin;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        destenation = Player.transform.position;

    }


    public void FixedUpdate()
    {
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed);
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
