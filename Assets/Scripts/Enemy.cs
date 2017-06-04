using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	[SerializeField]
	protected int health;
	public string eType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
			Destroy (this.gameObject);
	}
	
	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	public virtual void Go()
	{
	}
}
