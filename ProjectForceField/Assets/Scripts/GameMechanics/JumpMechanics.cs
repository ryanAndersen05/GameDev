using UnityEngine;
using System.Collections;

public class JumpMechanics : MonoBehaviour {
    public float jumpTime;


    private float jumpTimer;
    private int canJump;
    private Rigidbody rigid;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        updateJumpTimer();
    }

    void updateJumpTimer()
    {
        float prevTimer = jumpTimer;
        jumpTimer -= Time.deltaTime;
        if (jumpTimer < 0)
        {
            jumpTimer = 0;
            if (prevTimer > jumpTimer)
            {
                completeJump();
            }
        }
    }

    public bool getIsJumping()
    {
        return jumpTimer > 0;
    }

    public  void setCanJump(bool canJump)
    {
        if (canJump)
        {
            this.canJump++;
        }
        else
        {
            this.canJump--;
        }
    }

    public void jump(bool jumpButton)
    {
        if (jumpButton && canJump > 0)
        {
            anim.applyRootMotion = true;
            anim.SetTrigger("Jump");
            jumpTimer = jumpTime;
            //rigid.isKinematic = true;
        }
    }

    public void completeJump()
    {
        anim.applyRootMotion = false;
        rigid.isKinematic = false;
    }
}
