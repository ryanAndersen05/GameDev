using UnityEngine;
using System.Collections;

public class ClimbMechanics : MonoBehaviour {
    public float checkDistance = 1;
    public Transform originCheck;
    public float climbTime = 1.2f;

    Vector3 climbPoint;
    int climbMask = 1 << 10;
    float climbTimer;
    Rigidbody rigid;
    Animator anim;

    void Update()
    {
        updateClimbTimer();
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void checkClimb()
    {
        RaycastHit hit;
        if (!getIsClimbing() && Physics.Raycast(originCheck.position, this.transform.forward, out hit, checkDistance, climbMask))
        {
            climbTimer = climbTime;
            
            GetComponent<CapsuleCollider>().enabled = false;
            anim.applyRootMotion = true;

        }
    }

    void updateClimbTimer()
    {
        float prevClimb = climbTimer;
        climbTimer -= Time.deltaTime;
        if (climbTimer < 0)
        {
            climbTimer = 0;
            if (prevClimb > climbTimer)
            {
                completeClimb();
            }
        }
    }

    void completeClimb()
    {
        rigid.isKinematic = false;
        anim.applyRootMotion = false;
        GetComponent<CapsuleCollider>().enabled = true;

    }

    public bool getIsClimbing()
    {
        return climbTimer > 0f;
    }
}
