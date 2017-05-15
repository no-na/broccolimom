using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider2D ))]
public class AttackSling : Attack {

	// Use this for initialization
	void Start () {
		transform.GetComponent<SpriteRenderer>().color = Color.clear;
		transform.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//something has collided with the monster

		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
	}
	
	public override void DoAttack()
	{
		transform.GetComponent<SpriteRenderer>().color = Color.white;
		transform.GetComponent<Collider2D>().enabled = true;
	}
	
	public override void CancelAttack()
	{
		transform.GetComponent<SpriteRenderer>().color = Color.clear;
		transform.GetComponent<Collider2D>().enabled = false;
	}
	
	public override void Aim()
	{
		if (transform.parent.localScale.x > 0)
			transform.localPosition = new Vector3
			(
				Input.GetAxisRaw("Horizontal2")*2,
				Input.GetAxisRaw("Vertical2")*2, 
				200 * Time.deltaTime
			); 
		else
			transform.localPosition = new Vector3
			(
				Input.GetAxisRaw("Horizontal2")*-2,
				Input.GetAxisRaw("Vertical2")*2, 
				200 * Time.deltaTime
			); 
			
		float rotation = 0f;
		if(Input.GetAxisRaw("Vertical2") == 0)
			rotation = 0f;
		else if(Input.GetAxisRaw("Horizontal2") == 0)
			rotation = 90f;
		else if(Input.GetAxisRaw("Horizontal2") * Input.GetAxisRaw("Vertical2") > 0)
			rotation = 45f;
		else
			rotation = 120f;
		transform.localEulerAngles = new Vector3(0f,0f,rotation);
	}
}
