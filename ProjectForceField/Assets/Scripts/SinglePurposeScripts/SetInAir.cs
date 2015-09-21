using UnityEngine;
using System.Collections;

public class SetInAir : MonoBehaviour {
	public JumpMechanics jumpMechanics;

	void OnTriggerEnter(Collider collider) {
		jumpMechanics.setCanJump (true);
	}

	void OnTriggerExit(Collider collider) {
		jumpMechanics.setCanJump (false);
	}
}
