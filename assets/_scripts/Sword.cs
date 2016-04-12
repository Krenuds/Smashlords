using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	public bool hitPlayer;
	public GameObject playerHit;
	private Transform myTransform;

	void start()
	{
		myTransform = this.transform.parent.transform;
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D item)
	{
		if (item.tag == "Player" && item.transform != myTransform){
			playerHit = item.gameObject;
			hitPlayer = true;
		}
	}

	void OnTriggerExit2D(Collider2D item)
	{
		if (item.tag == "Player" && item.transform != myTransform){
			Debug.Log ("Out Of Melee Range");
			playerHit = null;
		}
	}
	
}
