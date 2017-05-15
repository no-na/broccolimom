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


        //position the shark
        //randomly pick one of the two targets
        GameObject playerTarget = null;

        while (playerTarget == null)
        {

            int ran = Random.Range(1, 2);
            if (ran == 1)
            {
                playerTarget = target1;
            }
            else
            {
                playerTarget = target2;
            }


        }

        //get in position
        transform.position = new Vector3(transform.position.x, playerTarget.transform.position.y, transform.position.z);

        Vector2 sharkDir = new Vector2();


        if (direction)
        {
            sharkDir = Vector2.right;
        }
        else
        {
            sharkDir = Vector2.left;
        }


    }

	public override void Go()
	{
        
	}

	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
			Destroy (this.gameObject);


        //zoom.
        rb2d.velocity = sharkDir * speed;

    }

    public void TakeDamage(int damage)
	{
		health -= damage;
	}


}
