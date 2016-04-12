using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInputController{

	public CharacterInputController instance;
	private float _horzontalAxis;
	private float _verticalAxis;

	private string[] actionsList;
	
	private Dictionary<string,bool> states = new Dictionary<string,bool>();

	private enum byteActions : byte {
		Jump = 0x0,
		Attack = 0x1,
		Grab = 0x2,
		Block = 0x3,
		Explode = 0x4,
		Fly = 0x5,

	}

//	private enum Actions {
//		Jump,
//		Attack,
//		Grab,
//		Block,
//		Explode,
//		Fly,
//	}

	public CharacterInputController () {
		instance = this;
		actionsList = System.Enum.GetNames(typeof(byteActions));

		foreach (string item in actionsList) {
			states.Add(item, false);
		}
	}

	public void Update () {
		SetAxis ();
		SetStates ();
	}
	//End Update
	private void SetStates ()
	{
		foreach (string action in actionsList) {
			states[action] = Input.GetButton(action);
		}
	}

	private void SetAxis()
	{
		_horzontalAxis = Input.GetAxis ("Horizontal");
		_verticalAxis = Input.GetAxis ("Vertical");
	}

	public Vector2 getAxis()
	{
		return new Vector2(_horzontalAxis,_verticalAxis);
	}

	public string[] ActionList
	{
		get {return actionsList; }
	}

	public Dictionary<string,bool> States
	{
		get {return states; } 
	}
}
