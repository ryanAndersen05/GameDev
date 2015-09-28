using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
    public GrabMechanics grabMechanics;

    Animator anim;
    WalkMechanics walkMechanics;
    ClimbMechanics climbMechanics;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        walkMechanics = GetComponent<WalkMechanics>();
        climbMechanics = GetComponent<ClimbMechanics>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", walkMechanics.getCurrentSpeedRatio());
        anim.SetBool("isGrabbing", grabMechanics.getIsGrabbing());
        anim.SetBool("isClimbing", climbMechanics.getIsClimbing());
	}
}
