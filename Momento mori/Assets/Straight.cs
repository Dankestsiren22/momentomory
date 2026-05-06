using UnityEngine;

public class Straight : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ActiveParry")
        {
            Destroy(gameObject);
        }
    }

}
