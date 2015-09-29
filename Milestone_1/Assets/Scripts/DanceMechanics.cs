using UnityEngine;
using System.Collections;

public class DanceMechanics : MonoBehaviour {
    ClimbMechanics climbMechanics;
    Animator anim;
    bool isDancing;
    float coolDownTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        climbMechanics = GetComponent<ClimbMechanics>();
    }

    void Update()
    {
        checkCompleteDancing();
    }

   void checkCompleteDancing()
    {
        if (isDancing && coolDownTimer <= 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Breakdance"))
        {
            completeDance();
        }
    }

    void completeDance()
    {
        GetComponent<CapsuleCollider>().enabled = true;

    }

    public void dance()
    {
        if (!climbMechanics.getIsClimbing() && !isDancing)
        {
            isDancing = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
