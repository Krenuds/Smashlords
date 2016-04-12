using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public float force = 20.0f;
	public float explodeRadius = 20.0f;
	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Rigidbody2D> () != null) {
			var dir = (other.transform.position - transform.position);
			float wearoff = 1 - (dir.magnitude / explodeRadius);
			other.rigidbody2D.AddForce(dir.normalized * force * wearoff);		
		}
	}




}
