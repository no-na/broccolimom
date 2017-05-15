using UnityEngine;
using System.Collections;

public class Anglerfish : Enemy {


	public bool direction = false;
	//true = rightwards motion; false = leftwards motion; defaults to leftwards

	private Rigidbody2D rb2d;

	//gameobjects for the two characters go here
	public GameObject target1;
	public GameObject target2;

	//how fast the monster moves
	public float speed;


	private float bobs = 2;
	private float bobTimer =2;

	private bool bobDir = true;

	//heavy enemy
	public int health = 8;

	void Start()
	{
		bobTimer = 0;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{

		if (health <= 0) {
			Destroy (this.gameObject);
		}

		//script to make character bob up and down a little bit
		bobTimer -=  Time.deltaTime;
		if (bobTimer <= 0) {

			Vector2 bobVector = new Vector2 ();

			if (bobDir) {
				bobVector = Vector2.up;
			} else {
				bobVector = Vector2.down;
			}


			rb2d.velocity = bobVector * speed;


			bobDir = !bobDir;
			bobTimer = bobs;
		}



	}

	public override void  Go()
	{
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	//this needs to betestedand will likely need to be rewritten
	void OnTriggerEnter2D (Collider2D other)
	{
			Attack a = other.gameObject.GetComponent<MonoBehaviour> () as Attack;
			if (a != null) {

				TakeDamage(a.Damage());
			}

		

	}

	void Attack()
	{
		//attack cue, code, etc. goes here



	}
}
