using UnityEngine;

public class objectdissapear : MonoBehaviour
{
    public float x;
    public Vector3 position;
    public Quaternion rotation;

    private void Awake()
    {
        transform.position = position;
        transform.rotation = rotation;
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
}
