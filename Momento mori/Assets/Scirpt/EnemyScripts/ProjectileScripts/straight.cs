using System.Collections;
using UnityEngine;

public class straight : MonoBehaviour
{
    public CombatMovement Player;
    public PlagueDoctorCombatBrain Boss;
    private void Start()
    {

        Destroy(gameObject, 5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ActiveParry")
        {
            Destroy(gameObject);
            Boss.Damage(1, Boss);
        }
        else if (other.tag == "Player")
        {
            // Destroy(gameObject);

        }
    }
}
