using UnityEngine;
using System.Collections;

public class UnityChanAnim : MonoBehaviour {
	Animator anim;
	WalkMechanics walkMechanics;
	JumpMechanics jumpMechanics;

	void Start() {
		anim = GetComponent<Animator> ();
		walkMechanics = GetComponent<WalkMechanics> ();
		jumpMechanics = GetComponent<JumpMechanics> ();
	}

	void Update() {
		anim.SetBool ("isWalking", walkMechanics.getIsWalking ());
		anim.SetBool ("isRunning", walkMechanics.getIsRunning ());
		anim.SetBool ("inAir", jumpMechanics.getInAir ());
	}
}
