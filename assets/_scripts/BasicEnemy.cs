using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float jumpSpeed = 1.0f;
	public Transform Target;
	public float knockSpeed = 5.0f;
	public int HP = 10;

	private float velX;
	private float velY;
	private Vector3 lookAtVector;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(HP <= 0){
			Destroy(gameObject);
		}
		lookAtVector = transform.position - Target.transform.position;
		if (lookAtVector.x < 0) {
			transform.localScale = new Vector2(-1,1);	
			rigidbody2D.AddForce (Vector2.right * moveSpeed);
			foreach(Collider2D collider in gameObject.GetComponentsInChildren<Collider2D>()) {
				collider.enabled=false;
				collider.enabled=true; }
		}				
		else {
			transform.localScale = new Vector3 (1, 1, 1);
			rigidbody2D.AddForce (-Vector2.right * moveSpeed);
		}
		velX = rigidbody2D.velocity.x;
		velY = rigidbody2D.velocity.y;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Terrain") {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
		}
		if (other.tag == "Weapon") {
			Debug.Log ("Weapon Trigger");
			if (velX < 0)
					rigidbody2D.velocity = new Vector2 (knockSpeed, velY);
			else
					rigidbody2D.velocity = new Vector2 (-knockSpeed, velY);
			HP -= 1;
		}
	}
}
