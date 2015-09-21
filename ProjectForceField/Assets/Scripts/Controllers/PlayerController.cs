using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float horizontalInput;
	float verticalInput;
	WalkMechanics walkMechanics;
	JumpMechanics jumpMechanics;

	void Update() {
		horizontalInput = Input.GetAxisRaw ("Horizontal");
		verticalInput = Input.GetAxisRaw ("Vertical");

		walkMechanics.setVerticalInput (verticalInput);
		walkMechanics.setHorizontalInput (horizontalInput);
		jumpMechanics.jump (Input.GetButtonDown ("Jump"));
	}

	void Start() {
		walkMechanics = GetComponent<WalkMechanics> ();
		jumpMechanics = GetComponent<JumpMechanics> ();
	}

}
