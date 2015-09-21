using UnityEngine;
using System.Collections;

public class JumpMechanics : MonoBehaviour {
	public float jumpForce = 5;
	public float jumpDelay = .15f;
	float jumpTimer;
	Rigidbody rigid;
	int canJump;

	void Start() {
		rigid = GetComponent<Rigidbody> ();
	}

	void Update() {
		jumpLogic ();
		print (canJump);
	}

	void jumpLogic() {
		float checkTime = jumpTimer;
		jumpTimer -= Time.deltaTime;

		if (jumpTimer < 0 && checkTime > 0) {
			rigid.AddForce (0, jumpForce, 0);
		}
		if (jumpTimer < 0) {
			jumpTimer = 0;
		}
	}

	public void jump(bool jumpButtonDown) {
		if (jumpButtonDown) {

			jumpTimer = jumpDelay;
		}
	}

	public void setCanJump(bool canJump) {
		if (canJump) {
			this.canJump++;
		} else {
			this.canJump--;
		}
	}

	public bool getInAir() {
		return Mathf.Abs(rigid.velocity.y) > 0.001 && canJump == 0;
	}

	public bool getIsJumping() {
		return jumpTimer > 0;
	}
}
