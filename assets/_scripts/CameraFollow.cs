using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject objectToFollow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (objectToFollow != null) {
			transform.position = new Vector3 (objectToFollow.transform.position.x,
			objectToFollow.transform.position.y,
			transform.position.z);
		}
	}
}
