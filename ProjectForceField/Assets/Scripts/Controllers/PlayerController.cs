using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GrabMechanics grabMechanics;

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
        if (Input.GetButtonDown("Grab"))
        {
            grabMechanics.grab(true);
        }
        if (Input.GetButtonUp("Grab"))
        {
            grabMechanics.grab(false);
        }
	}

	void Start() {
		walkMechanics = GetComponent<WalkMechanics> ();
		jumpMechanics = GetComponent<JumpMechanics> ();
	}

}
