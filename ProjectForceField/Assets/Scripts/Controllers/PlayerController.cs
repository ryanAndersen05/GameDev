using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GrabMechanics grabMechanics;

    float horizontalInput;
	float verticalInput;
	WalkMechanics walkMechanics;
	JumpMechanics jumpMechanics;
    ClimbMechanics climbMechanics;


	void Update() {
        
		horizontalInput = Input.GetAxisRaw ("Horizontal");
		verticalInput = Input.GetAxisRaw ("Vertical");
        if (climbMechanics.getIsClimbing())
        {
            horizontalInput = 0;
            verticalInput = 0;
        }
        walkMechanics.setVerticalInput (verticalInput);
		walkMechanics.setHorizontalInput (horizontalInput);

        bool jumpButton = Input.GetButtonDown("Jump");
        if (jumpButton && !jumpMechanics.getIsJumping())
        {
            climbMechanics.checkClimb();
        }

        if (!climbMechanics.getIsClimbing())
        {
            jumpMechanics.jump(jumpButton);
        }
	}

	void Start() {
		walkMechanics = GetComponent<WalkMechanics> ();
		jumpMechanics = GetComponent<JumpMechanics> ();
        climbMechanics = GetComponent<ClimbMechanics>();
	}

}
