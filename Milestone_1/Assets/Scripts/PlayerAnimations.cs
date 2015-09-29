using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {
    Animator anim;
    WalkMechanics walkMechanics;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        walkMechanics = GetComponent<WalkMechanics>();
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("Speed", walkMechanics.getCurrentSpeedRatio());
	}


}
