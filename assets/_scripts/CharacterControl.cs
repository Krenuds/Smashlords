using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	public class CharacterControl: Photon.MonoBehaviour {

	public static CharacterControl instance;
	public float jumpSpeed = 5.0f;
	public float flySpeed = 1.0f;
	public float moveSpeed = 5.0f;
	public float brakeSpeed = 5.0f;

	private float direction;
	private float horizAxis;
	private float velX;
	private float velY;
	private string currentAction;

	public GameObject weapon;

	private bool isGrounded = true;

	private CharacterInputController inputControl;

	void Start () {
		instance = this;
		inputControl = new CharacterInputController ();
	}
	
	// Update is called once per frame
	void Update () {
		currentAction = null;
		SetVector ();
		MovePawn ();
		inputControl.Update ();
	}

	void MovePawn(){
		ConsiderInput ();
		SetDirection ();
		rigidbody2D.AddForce (Vector2.right * horizAxis * moveSpeed );
		AddFriction ();
	}

	void SetDirection()
	{
		if (horizAxis < 0 && direction == 1) {
			transform.localScale = new Vector2 (-1, 1);
			
		} else if (horizAxis > 0)
			transform.localScale = new Vector2 (1, 1);
	}

	void SetVector()
	{
		direction = transform.localScale.x;
		horizAxis = inputControl.getAxis ().x;
		velX = rigidbody2D.velocity.x;
	}

	void ConsiderInput(){
		foreach (string item in inputControl.ActionList) {
			if(inputControl.States[item])
			{
				currentAction = item;
				SendMessage(item);

			}
		}
	}

	void AddFriction ()
	{
		if (horizAxis == 0 && velX != 0 && isGrounded) {
			rigidbody2D.AddForce(Vector2.right * -velX * brakeSpeed);
		}
	}

	void Fly()
	{
		rigidbody2D.AddForce (Vector2.up * flySpeed * 10);
	}

	void Jump (){
		if (isGrounded)
		rigidbody2D.velocity = new Vector2(velX, jumpSpeed);
		isGrounded = false;
	}

	public string GetCurrentAction
	{
		get {return currentAction;}
	}
	

	void OnTriggerEnter2D(Collider2D other){
		isGrounded = true;
		if (other.tag == "movingPlatform") {
			transform.parent = other.transform;
		}

	}

	void OnTriggerExit2D(Collider2D other){
		isGrounded = false;
		transform.parent = null;
		transform.eulerAngles = new Vector3 (0, 0,0);
	}

//	void OnTriggerStay2D(Collider2D other){
//		isGrounded = true;
//
//	}
}
