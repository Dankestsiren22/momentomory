using System.Collections;
using UnityEngine;

public class straight : MonoBehaviour
{
    public CombatMovement Player;
    private void Start()
    {
        StartCoroutine(Spawn());
        Destroy(gameObject, 5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ActiveParry")
        {
            Destroy(gameObject);
            
        }
        else if (other.tag == "Player")
        {
            Destroy(gameObject);
            Player.Damage();
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
