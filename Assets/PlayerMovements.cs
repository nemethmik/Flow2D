using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
	const string RunningParam = "Running";
	Rigidbody2D myRigidBody; // This is only for performance optimization
	Animator myAnimator;
	[SerializeField] float jumpForce = 7;
	public float runSpeed = 7;
	public LayerMask terrain = 6;
	enum Animations { Idle, Running, Jumping, Falling}
	// Start is called before the first frame update
	private void Start() {
		UnityEngine.Debug.Log($"Hello from Unity Terrain LayerMask is {(int)terrain}");
		myRigidBody = this.GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}
	int refreshRateCounter = 0;
	// Update is called once per frame
	private void Update() {		
		//if (refreshRateCounter % 140 == 0) {
		//	UnityEngine.Debug.Log($"Refresh Rate Counter {refreshRateCounter} ");
		//}
		refreshRateCounter++;
		//float x = Input.GetAxis("Horizontal");
		//myRigidBody.velocity = new Vector2 (x * 7.0f, myRigidBody.velocity.y);
		//if (UnityEngine.Input.GetKeyDown(KeyCode.Space)) {
		var a = ChangeAnimation();
		//if (a == Animations.Idle || a == Animations.Running) { // We are not mid-air
			//float x = Input.GetAxis("Horizontal");
			float x = Input.GetAxisRaw("Horizontal"); // if x == 0, the player doesn't move
			myRigidBody.velocity = new Vector2(x * runSpeed, myRigidBody.velocity.y);
		//}
		if (UnityEngine.Input.GetButtonDown("Jump") && !isMidAir()) {
			//myRigidBody.velocity = new Vector3(0,7,0);
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			Debug.Log($"Jump up at {refreshRateCounter}");
		}
	}
	private Animations ChangeAnimation() {
		//float x = myRigidBody.velocity.x;
		float x = Input.GetAxisRaw("Horizontal"); // if x == 0, the player doesn't move
		Animations animations = Animations.Idle;
		if (myRigidBody.velocity.y > 0.1) {
			animations = Animations.Jumping;
		} else if(myRigidBody.velocity.y < -0.1) {
 			animations = Animations.Falling;
		} else {
			if (x < 0) {
				//myAnimator.SetBool(RunningParam, true);
				animations = Animations.Running;
				GetComponent<SpriteRenderer>().flipX = true;
			} else if (x > 0) {
				//myAnimator.SetBool(RunningParam, true);
				animations = Animations.Running;
				GetComponent<SpriteRenderer>().flipX = false;
			} else {
				//myAnimator.SetBool(RunningParam, false);
			}
		}
		myAnimator.SetInteger("ActiveAnimation", (int)animations);
		return animations;
	}
	bool isMidAir() {
		BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
		return !Physics2D.BoxCast(boxCollider.bounds.center, 
			boxCollider.bounds.size, 0, Vector2.down, 0.1f, terrain); //terrain
	}
}