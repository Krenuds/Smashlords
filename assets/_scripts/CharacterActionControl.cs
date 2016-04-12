using UnityEngine;
using System.Collections;

public class CharacterActionControl : Photon.MonoBehaviour {
	private Animator animator;
	private Animator packAnimator;
	private bool isBlocking = false;

	public bool hasWeapon = true;

	private NetworkCharacter myNetChar;
	public CharacterStats myStats = new CharacterStats ();
	private PhotonPlayer currentEnemy;
	private Sword sword;
	
	public static CharacterActionControl instance;

	void Update()
	{
		if (myStats.HP <= 0) {
			Debug.Log("You're Dead!");		
		}
	}

	void Start()
	{
		myNetChar = gameObject.GetComponent<NetworkCharacter> ();
		if(hasWeapon)
		{
			sword = transform.Find("Sword").GetComponent<Sword>();
		}

		instance = this;
		animator = gameObject.GetComponent<Animator>();
		packAnimator = transform.Find("BackSlot").transform.Find("Jetpack").GetComponent<Animator>();
	}

	public void Attack()
	{
		if (myStats.Stamina > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("pawn_swingSword")){
			if(sword.hitPlayer)
			{
				currentEnemy = sword.playerHit.GetPhotonView().owner;
				//Debug.Log("Hit: " + sword.playerHit.name + " - " + currentEnemy.ToString());
				photonView.RPC("DealMeleeDamage", currentEnemy);
			}
			animator.SetTrigger ("swingWeapon");
			sword.playerHit = null;
			sword.hitPlayer = false;
			myStats.Stamina--;
			return;
		}
	}

	public void Explode()
	{
		animator.SetTrigger ("explode");
		myStats.Stamina++;
		return;
	}

	public void Grab()
	{

	}
	public void Fly ()
	{
		packAnimator.SetTrigger ("jetpack");
		return;

	}

	public void Block ()
	{
		isBlocking = !isBlocking;
		animator.SetBool ("block", isBlocking);
		return;
	}
	[RPC]
	private void DealMeleeDamage ()
	{
		myStats.TakeDamage (1);


	}
}