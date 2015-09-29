using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    WalkMechanics walkMechanics;
    ClimbMechanics climbMechanics;
    Animator anim;
    void Start()
    {
        walkMechanics = GetComponent < WalkMechanics>();
        climbMechanics = GetComponent<ClimbMechanics>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        walkMechanics.setVerticalInput(Input.GetAxis("Vertical"));
        walkMechanics.setHorizontalInput(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            climbMechanics.checkClimb();
        }
        if (Input.GetButtonDown("Dance") )
        {
            anim.SetTrigger("Dance");
        }

    }
}
