using UnityEngine;

public class paryable : MonoBehaviour
{
    public float x;
    public Vector3 position;
    public Quaternion rotation;
    public bool parried;
    public EnemyAi enemy;

    private void Awake()
    {
        transform.position = position;
        transform.rotation = rotation;
        parried = false;
        enemy = FindFirstObjectByType<EnemyAi>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ouch(x);
    }

    public void ouch(float x)
    {
        Destroy(gameObject, x);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ActiveParry")
        {
            Destroy(gameObject);
            enemy.CurrentHealth--;
        }
    }
}
