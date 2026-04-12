using UnityEngine;

public class straight : MonoBehaviour
{
    public PlagueDoctor Boss;
    public CombatMovement Player;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ActiveParry")
        {
            Destroy(gameObject);
            Boss.Damage();
        }
        else if (other.tag == "Player")
        {
            Destroy(gameObject);
            Player.Damage();
        }
    }

}
