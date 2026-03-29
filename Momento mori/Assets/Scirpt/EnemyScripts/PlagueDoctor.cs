using UnityEngine;
using System.Collections;

public class PlagueDoctor : MonoBehaviour
{
    public Animator animator;
    public int health;

    public void Damage()
    {
        health--;
    }


    public bool canswipe;
    public bool canstraight;
    public bool canleech;

    public int swipeCD;
    public int straightCD;
    public int leechCD;

    public GameObject swipe;
    public GameObject straight;
    public GameObject leech;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlaySwipe()
    {
        animator.SetTrigger("Swipe");
        animator.ResetTrigger("Swipe");
    }
    public void Swipe()
    {

        if (canswipe == true)
        {
            Instantiate(swipe);
            canswipe = false;
            StartCoroutine(SwipeCooldown());
        }
        
    }
    public void PlayStraight()
    {
        animator.SetTrigger("Straight");
        animator.ResetTrigger("Straight");
    }
    public void Straight()
    {
        if (canstraight == true)
        {
            Instantiate(straight);
            canstraight = false;
            StartCoroutine(StraightCooldown());
        }
    }

    public void PlayLeech()
    {
        animator.SetTrigger("Leech");
        animator.ResetTrigger("Leech");
    }
    public void Leech()
    {
        if (canleech == true)
        {
            Instantiate(leech);
            canstraight = false;
            StartCoroutine(LeechCooldown());
        }
    }

    IEnumerator SwipeCooldown()
    {
        yield return new WaitForSeconds(swipeCD);
        canswipe = true;
    }

    IEnumerator StraightCooldown()
    {
        yield return new WaitForSeconds(straightCD);
        canstraight = true;
    }

    IEnumerator LeechCooldown()
    {
        yield return new WaitForSeconds(leechCD);
        canleech = true;
    }
    
    
}
