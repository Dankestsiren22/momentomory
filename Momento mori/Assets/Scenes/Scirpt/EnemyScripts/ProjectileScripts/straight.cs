using System.Collections;
using UnityEngine;

public class straight : MonoBehaviour
{
    public CombatMovement Player;
    public GameObject Parent;



    public void Damage()
    {
        Parent.GetComponent<HealthHandler>().Health--;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
        Destroy(gameObject, 1f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ActiveParry")
        {
            Damage();
            Destroy(gameObject);
            
        }
        else if (other.tag == "Player")
        {
            Player.health = 3;
        }
    }
    IEnumerator Spawn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        transform.GetChild(2).gameObject.SetActive(true);
    }

}
