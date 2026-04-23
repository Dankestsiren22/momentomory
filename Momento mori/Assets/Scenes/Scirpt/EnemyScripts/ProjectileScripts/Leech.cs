using UnityEngine;

public class Leech : MonoBehaviour
{
    public Transform TargetPosition;
    int speed = 5;
    
    public void Awake()
    {
       
    }
    void Start()
    {
    }
    void Update()
    {
        MoveToTargetPosition(TargetPosition);

    }

    private void MoveToTargetPosition(Transform Target)
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
    }
}
