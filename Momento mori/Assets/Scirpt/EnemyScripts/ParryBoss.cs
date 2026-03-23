using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class ParryBoss : MonoBehaviour
{
    public int health;
    public int ParryBallCD;
    public bool CanParryBall;
    public GameObject ParryBall;
    public GameObject BasicAttak;
    public GameObject swip;
    public GameObject slash;
    public int SwipCD;
    public int SlashCD;
    public bool CanSwipe;
    public bool CanSlash;
    public bool CanBasic;

    void Awake()
    {
        CanParryBall = false;
        StartCoroutine((ParryBallCoolDown()));
        CanBasic = false;
        StartCoroutine(BasicBallCD());
        CanSwipe = false;
        StartCoroutine(SwipeCooldown());
        CanSlash = false;
        StartCoroutine(SlashCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (CanParryBall == true)
            ParryBallAttack();
        if (CanBasic == true)
            BasicAttack();
        if (CanSwipe == true)
            SwipeAttack();
        if (CanSlash == true)
            SlashAttack();

        
    }

    public void ParryBallAttack()
    {
        GameObject p = Instantiate(ParryBall, transform.position, transform.rotation);
        Destroy(p, .1f);
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

    public void SwipeAttack()
    {
        GameObject p = Instantiate(swip, transform.position, transform.rotation);
        Destroy(p, 1);
        CanSwipe = false;
    }

    public void SlashAttack()
    {
        GameObject p = Instantiate(slash, new Vector3(transform.position.x, transform.position.y - 4f, transform.position.z), transform.rotation);
        CanSlash = false;
        Destroy(p, 1);
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

    IEnumerator SwipeCooldown()
    {
        yield return new WaitForSeconds(SwipCD);
        CanSwipe = true;
    }

    IEnumerator SlashCooldown()
    {
        yield return new WaitForSeconds(SlashCD);
        CanSlash = true;
    }
}
