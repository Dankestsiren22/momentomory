using UnityEngine;
using System.Collections;

public class ParryBoss : MonoBehaviour
{
    public int health;
    public int ParryBallCD;
    public bool CanParryBall;
    public GameObject ParryBall;

    void Awake()
    {
        CanParryBall = false;
        StartCoroutine((ParryBallCoolDown()));
    }

    // Update is called once per frame
    void Update()
    {
        if (CanParryBall == true)
            ParryBallAttack();
        
    }

    public void ParryBallAttack()
    {
        GameObject p = Instantiate(ParryBall, transform.position, transform.rotation);
        Destroy(p, 7f);
        CanParryBall = false;
        StartCoroutine((ParryBallCoolDown()));
    }
    IEnumerator ParryBallCoolDown()
    {
        yield return new WaitForSeconds(ParryBallCD);

        CanParryBall = true;
    }

}
