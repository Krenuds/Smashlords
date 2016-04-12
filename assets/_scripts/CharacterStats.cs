using UnityEngine;
using System.Collections;

public class CharacterStats{

	private string name;
	private float hp;
	private float stamina;
	private float meleeDamage;
	private float rangedDamage;

	public CharacterStats ()
	{
		name = "User";
		hp = 10.0f;
		stamina = 10.0f;
		meleeDamage = 1.0f;
		rangedDamage = 1.0f;

	}

	public CharacterStats (string _name)
	{
		name = _name;
		hp = 10.0f;
		stamina = 10.0f;
		meleeDamage = 1.2f;
		rangedDamage = 1.2f;
	}

	public string Name 
	{
		get {return name;}
		set {name = value;}
	}

	public float HP 
	{
		get {return hp;}
		set {hp = value;}
	}

	public float Stamina 
	{
		get {return stamina;}
		set {stamina = value;}
	}

	public float MeleeDamage 
	{
		get {return meleeDamage;}
		set {meleeDamage = value;}
	}

	public float RangedDamage 
	{
		get {return rangedDamage;}
		set {rangedDamage = value;}
	}

	public void TakeDamage (float damage)
	{
		hp -= damage;
	}

//	void Start () {
//	
//	}
//	
//	
//	void Update () {
//	
//	}
}
