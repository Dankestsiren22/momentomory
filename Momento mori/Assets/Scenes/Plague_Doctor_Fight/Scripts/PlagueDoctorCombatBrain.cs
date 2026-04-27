using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using TMPro;

public class PlagueDoctorCombatBrain : MonoBehaviour
{
    [SerializeField] private AudioClip[] attackSoundClips;
    public Transform[] TargetTransforms;
    public GameObject LeechPoint;
    public GameObject swipe;
    public GameObject straight;
    public GameObject leech;
    public GameObject Portal;
    public GameObject StraightOutline;

    public CombatMovement Player;
    public float Distance; //from the center of map not the boss
    public bool CanAttack;
    public int sequence;
    public Animator animator;
    public bool attacking;

    public float AttackCD = 1;

    
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
            sequence = Random.Range(1,3);
            Combo(sequence);
            AttackCD = Random.Range(2f,5f);
            StartCoroutine(Attacd());
        }
        else { Debug.Log(AttackCD); }
    }

    private IEnumerator Attacd()
    {
        while (AttackCD > 0)
        {
            AttackCD -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        AttackCD = 0;
        Attack();
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
        
        //SFX
        SoundFXManager.instance.PlayRandomSoundFXClip(attackSoundClips, transform, 1f);

        yield return new WaitForSeconds(0.9f);

        PlayStraight();

        //SFX
        SoundFXManager.instance.PlayRandomSoundFXClip(attackSoundClips, transform, 1f);

        yield return new WaitForSeconds(0.8f);

        Debug.Log("Played sequence");
    }
    public IEnumerator Sequence2()
    {
        PlaySwipe();

        //SFX
        SoundFXManager.instance.PlayRandomSoundFXClip(attackSoundClips, transform, 1f);

        yield return new WaitForSeconds(0.9f);

        PlaySwipe();

        //SFX
        SoundFXManager.instance.PlayRandomSoundFXClip(attackSoundClips, transform, 1f);

        yield return new WaitForSeconds(0.8f);

        Debug.Log("Played sequence");
    }
    public void PlayLeech()
    {
       attacking = true;
       animator.Play("Doctor-Leech-REAL");     
    }
    public void PlayStraight()
    {
        Vector3 Spot1 = new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z);
        Instantiate(StraightOutline, Spot1, transform.rotation);
        animator.Play("Doctorr-Straight-REAL");
    }
    public void PlaySwipe()
    {
       animator.Play("Doctor-Swipe_REAL");       
    }
    public void Swipe()
    {
        Instantiate(swipe);
    }
    public void Straight(float x)
    {
        Vector3 Spot = new Vector3(transform.position.x, transform.position.y - x, transform.position.z);
        GameObject p = Instantiate(straight, Spot, transform.rotation);
        straight l = p.GetComponent<straight>();
        l.Parent = gameObject;
        
    }
    public void Leech(int TragetPosition)
    {
        GameObject GameObj = Instantiate(leech, LeechPoint.gameObject.transform.position, (LeechPoint.gameObject.transform.rotation));
        Leech lech = GameObj.GetComponent<Leech>();
        lech.TargetPosition = TargetTransforms[TragetPosition];
    }
    public void portal()
    {
        Instantiate(Portal);
    }
}
