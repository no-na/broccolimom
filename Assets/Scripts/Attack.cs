using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {
	
	[SerializeField]
	protected DemoScene controller; 
	
	[SerializeField]
	protected int damage; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int Damage()
	{
		return damage;
	}
	
	public abstract void DoAttack();
	
	public abstract void CancelAttack();
	
	public abstract void Aim();
	
}
