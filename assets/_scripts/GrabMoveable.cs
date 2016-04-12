using UnityEngine;
using System.Collections;

public class GrabMoveable : MonoBehaviour {

	
	private bool isHolding = false;
	private DistanceJoint2D currentHinge;

	public void Update () {
		if(currentHinge != null){
			if (Input.GetButton("Grab") && !isHolding) PickupObject ();
			if (Input.GetButton("Drop") && isHolding) DropObject ();
		}
	}

	void PickupObject(){
		currentHinge.connectedBody = transform.parent.rigidbody2D;
		currentHinge.enabled = true;
		isHolding = true;
	}

	void DropObject()
	{
		currentHinge.enabled = false;
		currentHinge = null;
		isHolding = false;

	}

	void OnTriggerEnter2D(Collider2D item){
		if (item.GetComponent<DistanceJoint2D>()!= null && item.tag == "moveable"){
			currentHinge = item.GetComponent<DistanceJoint2D>();
			}
	}

	void OnTriggerExit2D(Collider2D item){
		currentHinge = null;
	}
}
