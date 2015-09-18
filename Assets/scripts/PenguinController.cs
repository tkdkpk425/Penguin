using UnityEngine;
using System.Collections;

public class PenguinController : MonoBehaviour {
	public Camera cam;
	public float maxSpeed = 20f;


	Animator anim;
	float jumpForce = 650f;
	Rigidbody2D myBody; 
	bool facingRight = false;
	bool grounded = false;
	bool doubleJump = false;
	public Transform GroundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	bool moveRight = false;
	private float maxWidth;
	private float speed = 1f;
	private float acceleration = 1f;
	private float maxAcceleration = 20f;

	// Use this for initialization
	void Start () {
		print("start in PenguinController");
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector2 (Screen.width, Screen.height);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		GroundCheck = transform.Find ("GroundCheck");
		//set initial velocity
		myBody.velocity = new Vector2 (1 , GetComponent<Rigidbody2D> ().velocity.y);
		anim.SetFloat ("speed", Mathf.Abs (1));
		
	}

	
	// Update is called once per physics timestemp
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, 1 << LayerMask.NameToLayer("Default"));
		anim.SetBool ("Ground", grounded);
		float move = Input.GetAxis ("Horizontal");

		//print("mouse =" + mousePosition.x);
		//flip sprite
		if (moveRight && !facingRight) {
			Flip ();
				acceleration =1;
		} else if (facingRight && !moveRight) {
			Flip ();
				acceleration = 1;
		}

			if (moveRight) {
				myBody.velocity = new Vector2 ( speed *acceleration, GetComponent<Rigidbody2D> ().velocity.y);
				anim.SetFloat ("speed", Mathf.Abs (1));
			} else {
				myBody.velocity = new Vector2(-speed * acceleration, GetComponent<Rigidbody2D>().velocity.y);
				anim.SetFloat ("speed", Mathf.Abs(1));
		    }			
			//print("velocity =" + myBody.velocity.x);
			//print ("position =" + transform.position.x);

	//when penguin goes out of bound return it to other side of the screen
	if(transform.position.x < (-maxWidth - GetComponent<SpriteRenderer>().bounds.size.x/2 )) {
		transform.position= new Vector3(maxWidth+GetComponent<SpriteRenderer>().bounds.size.x/2, transform.position.y, 0);
	}
	if(transform.position.x > (maxWidth + GetComponent<SpriteRenderer>().bounds.size.x/2)) {
		transform.position= new Vector3(-maxWidth-GetComponent<SpriteRenderer>().bounds.size.x/2, transform.position.y, 0);
	}	//}

}

	void Update() {

		Vector3 mousePosition ;
		//get acceleration and check max
		acceleration = acceleration + 3*Time.deltaTime*acceleration;
		if(acceleration >= maxAcceleration) {
			acceleration = maxAcceleration;
		}
	//print ("getTouch = " + Input.GetAxis ("Mouse X");
	//Vector3 mousePosition = cam.ScreenToWorldPoint (new Vector2(Input.GetTouch(0).position.x,0));
	//if (Input.touchCount > 0) {
	//	for(int i =0; i < Input.touchCount; i++) {
	//		Touch touch = Input.GetTouch(i);
	//		if (touch.phase == TouchPhase.Began) {
	//			print("got touch");
		if(Input.GetMouseButtonDown(0)) {
			//					mousePosition = cam.ScreenToWorldPoint (new Vector2(Input.GetTouch(i).position.x,0));
			mousePosition = cam.ScreenToWorldPoint (new Vector2(Input.mousePosition.x,0));
			
			//determine to move left or right
			if(mousePosition.x > 0) {
				moveRight  = true;
			} else {
				moveRight = false;
			}
		}	
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
		//set initial velocity again when character changes moving direction
			if (moveRight) {
			myBody.velocity = new Vector2 (1 , GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetFloat ("speed", Mathf.Abs (1));
		} else {
			myBody.velocity = new Vector2(-1, GetComponent<Rigidbody2D>().velocity.y);
			anim.SetFloat ("speed", Mathf.Abs(1));
		}	transform.localScale = theScale;

	}
}
