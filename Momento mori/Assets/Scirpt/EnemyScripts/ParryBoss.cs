using UnityEngine;
using System.Collections;

public class ParryBoss : MonoBehaviour
{
    public int health;
    public int ParryBallCD;
    public bool CanParryBall;
    public GameObject ParryBall;
    public GameObject BasicAttak;
    public bool CanBasic;

    void Awake()
    {
        CanParryBall = false;
        StartCoroutine((ParryBallCoolDown()));
        CanBasic = false;
        StartCoroutine(BasicBallCD());
    }

    // Update is called once per frame
    void Update()
    {
        if (CanParryBall == true)
            ParryBallAttack();
        if (CanBasic == true)
            BasicAttack();

        
    }

    public void ParryBallAttack()
    {
        GameObject p = Instantiate(ParryBall, transform.position, transform.rotation);
        Destroy(p, 7f);
        CanParryBall = false;
        StartCoroutine((ParryBallCoolDown()));
    }

    public void BasicAttack()
    {
        GameObject p = Instantiate(BasicAttak, transform.position, transform.rotation);
        Destroy(p, 4);
        CanBasic = false;
        StartCoroutine(BasicBallCD());
    }
    IEnumerator ParryBallCoolDown()
    {
        yield return new WaitForSeconds(ParryBallCD);

        CanParryBall = true;
    }

    IEnumerator BasicBallCD()
    {
        yield return new WaitForSeconds(ParryBallCD);
        CanBasic = true;
    }

}
