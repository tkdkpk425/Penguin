using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public Camera cam;
	public float maxSpeed = 10f;
	bool facingRight = false;
	Animator anim;
	float jumpForce = 650f;
	Rigidbody2D myBody; 

	bool grounded = false;
	bool doubleJump = false;
	public Transform GroundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	float lastMove;

	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector2 (Screen.width, Screen.height);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		GroundCheck = transform.Find ("GroundCheck");

	}

	
	// Update is called once per physics timestemp
	void FixedUpdate () {
		/*
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, myBody.position.y, 0.0f);
		float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		myBody.MovePosition (targetPosition);
		*/
		grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, 1 << LayerMask.NameToLayer("Default"));
		anim.SetBool ("Ground", grounded);
		float move = Input.GetAxis ("Horizontal");

		if (move > 0.3 || move < -0.3) {
			lastMove = move;
			myBody.velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetFloat ("speed", Mathf.Abs (move));
		} else {
			myBody.velocity = new Vector2(lastMove * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			anim.SetFloat ("speed", Mathf.Abs(move));
		}
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

		
	}

	void Update() {

		if(Input.GetKeyDown(KeyCode.Space)) {
			if(!grounded && doubleJump == false) {
				myBody.AddForce(new Vector2(0,jumpForce));
				doubleJump = true;
			}
			if (grounded == true) {
				myBody.AddForce(new Vector2(0,(jumpForce-50f)));
				doubleJump = false;
			}
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
