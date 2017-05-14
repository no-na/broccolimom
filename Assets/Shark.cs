using UnityEngine;
using System.Collections;

public class Shark : Enemy {


	public bool direction = false;
	//true = rightwards motion; false = leftwards motion; defaults to leftwards

	private Rigidbody2D rb2d;

	//gameobjects for the two characters go here
	public GameObject target1;
	public GameObject target2;

	//how fast the monster moves
	public float speed;

	//shark
	private int health = 1;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	public void Go()
	{

		//randomly pick one of the two targets
		GameObject playerTarget = null;

		while (playerTarget == null) {

			int ran = Random.Range (1, 2);
			if (ran == 1) {
				playerTarget = target1;
			} else {
				playerTarget = target2;
			}
				

		}

		//get in position
		transform.position.y = playerTarget.transform.position.y;

		Vector2 sharkDir = new Vector2 ();


		if (direction) {
			sharkDir = Vector2.right;
		} else {
			sharkDir = Vector2.left;
		}

		//zoom.
		rb2d.velocity = sharkDir * speed;




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

	//this needs to betestedand will likely need to be rewritten
	void OnTriggerEnter2D (Collider2D other)
	{
		void OnTriggerEnter2D (Collider2D other)
		{
			Attack a = other.gameObject.getComponent<MonoBehaviour> () as Attack;
			if (a != null) {

				TakeDamage(a.damage);
			}

		}

	}


}
