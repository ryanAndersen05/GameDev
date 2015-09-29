using UnityEngine;
using System.Collections;

public class ClimbMechanics : MonoBehaviour {
    public Transform climbOrigin;
    public float checkDistance;

    private int climbMask = 1<<8;
    Animator anim;
    bool isClimbing;
    float coolDownTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        updateCoolDownTimer();
        print(anim.GetCurrentAnimatorClipInfo(0).ToString());
        if (isClimbing && (coolDownTimer <= 0 && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Climbing")))
        {
            completeClimb();
        }
    }

    void updateCoolDownTimer()
    {
        coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
    }

    public void checkClimb()
    {
        RaycastHit hit;
        if (Physics.Raycast(climbOrigin.position, transform.forward, out hit, checkDistance, climbMask))
        {
            anim.SetTrigger("Climb");
            GetComponent<CapsuleCollider>().enabled = false;
            isClimbing = true;
            coolDownTimer = .3f;
        }
    }

    void completeClimb()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        isClimbing = false;
        
    }

    public bool getIsClimbing()
    {
        return isClimbing;
    }
}
