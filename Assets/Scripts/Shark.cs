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
    

	void Start () {
		eType = "Shark";

		this.gameObject.tag = "Enemy";

		rb2d = GetComponent<Rigidbody2D> ();




    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Attack a = other.gameObject.GetComponent<MonoBehaviour>() as Attack;
        if (a != null)
        {

            TakeDamage(a.Damage());
        }

    }

    public override void Go()
    {


        //position the shark
        //randomly pick one of the two targets
        GameObject playerTarget = null;

        while (playerTarget == null)
        {


            if (target2 == null)
            {
                playerTarget = target1;

            }
            else if (target1 == null)
            {
                playerTarget = target2;

            }

            else
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
		



    }

	void OnCollisionEnter2D(Collision2D other)
	{
		//ignore the collision w/ other enemies
		if (other.gameObject.tag == "Enemy") {
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
		}
	}

}
