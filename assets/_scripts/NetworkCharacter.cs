using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	private Vector2 correctPlayerPos = Vector2.zero; //We lerp towards this
	private Vector2 correctPlayerScale = Vector3.zero;
	private Vector2 correctPlayerVel = Vector2.zero;
	private string correctPlayerAnim;
	public int SmoothingDelay = 5;

	private PhotonPlayer enemyPlayer;

	void Start () {

		if (!photonView.isMine) {
			enemyPlayer = photonView.owner;
			gameObject.GetComponent<CharacterControl>().enabled = false;
		}
		else{
			gameObject.GetComponent<CharacterControl>().enabled = true;

		}
	}

	public PhotonPlayer EnemyPlayer
	{
		get {return enemyPlayer;}
	}

	// Update is called once per frame
	void Update () {

		if (!photonView.isMine)
		{
			transform.position = Vector2.Lerp(transform.position, correctPlayerPos, Time.deltaTime * this.SmoothingDelay);
			transform.localScale = correctPlayerScale;
			rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, correctPlayerVel, Time.deltaTime * this.SmoothingDelay);
			if(correctPlayerAnim != null)
			SendMessage(correctPlayerAnim);
		}

	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			correctPlayerAnim = null;
			stream.SendNext(gameObject.GetComponent<CharacterControl>().GetCurrentAction);
			stream.SendNext(transform.position);
			stream.SendNext(transform.localScale);
			stream.SendNext(rigidbody2D.velocity);
		}
		else
		{
			correctPlayerAnim =  (string)stream.ReceiveNext();
			correctPlayerPos =   (Vector3)stream.ReceiveNext();
			correctPlayerScale = (Vector3)stream.ReceiveNext();
			correctPlayerVel =   (Vector2)stream.ReceiveNext();
		}
	}
}
