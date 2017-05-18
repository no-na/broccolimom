using UnityEngine;
using System.Collections;

public class Shark : Enemy {
    public string playerTag;

	public bool direction = false;
	//true = rightwards motion; false = leftwards motion; defaults to leftwards

	private Rigidbody2D rb2d;

	//gameobjects for the two characters go here
	public GameObject target1;
	public GameObject target2;

	//how fast the monster moves
	public float speed;

    public Vector2 sharkDir;

	//shark
	private int health = 1;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();




    }

    public override void Go()
    {


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

        sharkDir = new Vector2();


        if (direction)
        {
            sharkDir = Vector2.right;
        }
        else
        {
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

    //player collision!
    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            health = 0;
        }
    }

}
