using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using TMPro;

public class PlagueDoctorCombatBrain : MonoBehaviour
{
    TextMeshProUGUI Countdwon;
    public Transform[] TargetTransforms;
    public GameObject LeechPoint;
    RuntimeAnimatorController rac;
    public GameObject swipe;
    public GameObject straight;
    public GameObject leech;

    public CombatMovement Player;
    public float Distance; //from the center of map not the boss
    public bool CanAttack;
    int sequence;
    public Animator animator;
    public bool attacking;

    public float AttackCD = 1;

    public void Awake()
    {
        
        rac = animator.runtimeAnimatorController;
    }
    public void Start()
    {
        StartCoroutine(Attacd());
    }
    void Update()
    {
        
    }
    public void Attack()
    {
        if (AttackCD == 0)
        {
            sequence = Random.Range(1, 2);
            Combo(sequence);
            AttackCD = Random.Range(1f, 2f);
        }
        else { Debug.Log(AttackCD); }
    }

    private IEnumerator Attacd()
    {
        while (AttackCD > 0)
        {
            Attack();
            AttackCD -= 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
        AttackCD = 0;
    }
    public void Combo(int sequence)
    {

        if (sequence == 1)
        {
            StartCoroutine(Sequence1());
            
        }
        else if (sequence == 2)
        {
            StartCoroutine(Sequence2());
        }
    }

    public IEnumerator Sequence1()
    {
        PlaySwipe();

        yield return new WaitForSeconds(0.8f);

        PlayStraight();

        yield return new WaitForSeconds(0.7f);

        Debug.Log("Played sequence");
    }
    public IEnumerator Sequence2()
    {
        PlaySwipe();

        yield return new WaitForSeconds(0.8f);

        PlaySwipe();

        yield return new WaitForSeconds(0.7f);

        Debug.Log("Played sequence");
    }
 
    public void PlayLeech(float x)
    {
       attacking = true;
       animator.Play("Doctor-Leech-Attack");     
    }
    public void PlayStraight()
    {

            animator.Play("Doctor-Straight-Attack");
    }
    public void PlaySwipe()
    {
            animator.Play("Doctor-Swipe-Attack");       
    }
   

    public void Swipe()
    {
        Instantiate(swipe);

    }

    public void Straight()
    {
        Instantiate(straight);


    }
    public void Leech(int TragetPosition)
    {
        GameObject GameObj = Instantiate(leech, LeechPoint.gameObject.transform.position, (LeechPoint.gameObject.transform.rotation));
        Leech lech = GameObj.GetComponent<Leech>();
        lech.TargetPosition = TargetTransforms[TragetPosition];
    }
}
