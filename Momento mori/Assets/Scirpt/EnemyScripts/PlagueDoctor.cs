using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class PlagueDoctor : MonoBehaviour
{
    public Transform[] TargetTransforms;
    public GameObject LeechPoint;
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
    public void Leech(int TragetPosition)
    {
        
        if (canleech == true)
        {
            GameObject GameObj = Instantiate(leech, LeechPoint.gameObject.transform.position, (LeechPoint.gameObject.transform.rotation));
            Leech lech = GameObj.GetComponent<Leech>();
            lech.TargetPosition = TargetTransforms[TragetPosition];
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
