using UnityEngine;
using System.Collections;

public class DebugInfo : Photon.MonoBehaviour {

	private float currentHp;
	private string playerName;
	public CharacterActionControl myActionControl;
	void Start () {
		myActionControl = gameObject.GetComponent<CharacterActionControl>();
		//playerName = gameObject.GetComponent<PhotonView>().owner.name;
	}
	
	// Update is called once per frame
	void Update () {

		currentHp = myActionControl.myStats.HP;
		if (Input.GetKeyDown("u") && myActionControl.myStats.HP > 0){
			myActionControl.myStats.HP--;	
		}
		Debug.Log (currentHp.ToString());
	
	}

	void OnGUI()
	{
			GUI.Box (new Rect(Screen.width - 120,10,110,100), "Debug Menu");
			GUI.Label (new Rect(Screen.width - 115,30,100,20), "Player: " + playerName);
			GUI.Label (new Rect(Screen.width - 115,60,100,20), "HitPoints: " + currentHp);
			GUI.Label (new Rect(Screen.width - 115,90,100,20), "Stamina: " + myActionControl.myStats.Stamina);
	}
}
